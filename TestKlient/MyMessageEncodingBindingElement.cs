using ApiClientShared.Enums;
using Difi.Felles.Utility.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Channels;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace TestKlient
{
    public class MyMessageEncodingBindingElement : MessageEncodingBindingElement
    {
        public TextMessageEncodingBindingElement textBE = new TextMessageEncodingBindingElement(MessageVersion.Soap12, Encoding.UTF8);


        public override MessageEncoderFactory CreateMessageEncoderFactory()
        {
            return new MyMessageEncoderFactory(textBE.CreateMessageEncoderFactory());
        }

        public override MessageVersion MessageVersion
        {
            get { return MessageVersion.Soap12; }
            set
            {
                if (value != MessageVersion.Soap12)
                {
                    throw new ArgumentException("Invalid message version");
                }
            }
        }

        public override BindingElement Clone()
        {
            return new MyMessageEncodingBindingElement();
        }

        public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
        {
            context.BindingParameters.Add(this);
            return context.BuildInnerChannelFactory<TChannel>();
        }

        public override IChannelListener<TChannel> BuildChannelListener<TChannel>(BindingContext context)
        {
            context.BindingParameters.Add(this);
            return context.BuildInnerChannelListener<TChannel>();
        }

        class MyMessageEncoderFactory : MessageEncoderFactory
        {
            MessageEncoder encoder;
            private MessageEncoderFactory text;

            public MyMessageEncoderFactory(MessageEncoderFactory messageEncoderFactory)
            {
                text = messageEncoderFactory;
            }

            private MyMessageEncoderFactory() { }

            public override MessageEncoder Encoder
            {
                get
                {
                    if (this.encoder == null)
                    {
                        this.encoder = new MyMessageEncoder(this.text.Encoder);
                    }

                    return this.encoder;
                }
            }

            public override MessageVersion MessageVersion
            {
                get { return this.text.MessageVersion; }
            }
        }

        class MyMessageEncoder : MessageEncoder
        {

            private readonly MessageEncoder _text;
            public MyMessageEncoder(MessageEncoder text)
            {

                this._text = text;
            }
            // Implementation of MessageEncoder

            public override Message ReadMessage(Stream stream, int maxSizeOfHeaders, string contentType)
            {
                
                var s = ProcessMemoryStream(stream);
              
                return this._text.ReadMessage(s, maxSizeOfHeaders, contentType);
            }

            public override Message ReadMessage(ArraySegment<byte> buffer, BufferManager bufferManager, string contentType)
            {
                byte[] msgContents = new byte[buffer.Count];
                Array.Copy(buffer.Array, buffer.Offset, msgContents, 0, msgContents.Length);
                bufferManager.ReturnBuffer(buffer.Array);

                MemoryStream stream = new MemoryStream(msgContents);
                return ReadMessage(stream, int.MaxValue);

            }

            public override void WriteMessage(Message message, Stream stream)
            {
                this._text.WriteMessage(message, stream);
            }

            public override ArraySegment<byte> WriteMessage(Message message, int maxMessageSize, BufferManager bufferManager, int messageOffset)
            {
                return this._text.WriteMessage(message, maxMessageSize, bufferManager, messageOffset);
            }

            public override string ContentType => "application/soap+xml;charset=utf-8";
            public override string MediaType => _text.MediaType;
            public override MessageVersion MessageVersion => _text.MessageVersion;


            private Stream ProcessMemoryStream(Stream inputStream)
            {
                List<string> referenceList = new List<string>();

                var xmlDoc = new XmlDocument();
                xmlDoc.PreserveWhitespace = true;
                xmlDoc.Load(inputStream);
                inputStream.Position = 0;
                

               // XmlNode security = xmlDoc.SelectSingleNode("//*[local-name()='Security']");

                XmlNode timestamp = xmlDoc.SelectSingleNode("//*[local-name()='Timestamp']");
                //referenceList.Add(timestamp.Attributes["wsu:Id"].Value);
                //timestamp.ParentNode.RemoveChild(timestamp);

                XmlNode signatureConfirmation = xmlDoc.SelectSingleNode("//*[local-name()='SignatureConfirmation']");
                referenceList.Add(signatureConfirmation.Attributes["wsu:Id"].Value);
                signatureConfirmation.ParentNode.RemoveChild(signatureConfirmation);

                foreach (string s in referenceList)
                {
                    XmlNode childNode = xmlDoc.SelectSingleNode("//*[@URI='#"+s+"']");
                    childNode.ParentNode.RemoveChild(childNode);
                }

            
                string raw = xmlDoc.OuterXml;
                raw = Regex.Replace(raw, @" />", "/>");

                MemoryStream xmlStream = new MemoryStream();
                xmlDoc.Save(xmlStream);
                xmlStream.Flush();//Adjust this if you want read your data 
                xmlStream.Position = 0;

                return xmlStream;
                
            }
            private void loopthrougStream(Stream inputStream)
            {
                try
                {
                    using (var reader = XmlReader.Create(inputStream))
                    {
                        while (reader.Read())
                        {

                            Console.WriteLine(reader.Name);
                        }
                        reader.Close();
                    }
                    inputStream.Position = 0;
                    
                }
                catch (Exception ex)
                {
                    // handle error
                    throw;
                }
            }

            private List<string> findReferenceId(Stream inputStream)
            {
                List<string> referenceList = new List<string>();
                try
                {
                    using (var reader = XmlReader.Create(inputStream))
                    {
                        while (reader.Read())
                        {
                            
                            if (reader.LocalName.Equals("Timestamp") && reader.NamespaceURI.Equals("http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"))
                            {
                                if (reader.HasAttributes)
                                {

                                    for (int attInd = 0; attInd < reader.AttributeCount; attInd++)
                                    {
                                        reader.MoveToAttribute(attInd);
                                        referenceList.Add(reader.Value);
                                    }
                                    // Move the reader back to the element node.
                                    reader.MoveToElement();

                                    
                                }
                            }
                        }
                        reader.Close();
                    }
                    inputStream.Position = 0;

                    return referenceList;
                }
                catch (Exception ex)
                {
                    // handle error
                    throw;
                }
            }

            private MemoryStream ProcessMemoryStream(Stream inputStream, bool dispose, List<string> referenceList)
            {
                StreamWriter xmlStream = null;
                var outputStream = new MemoryStream();
                bool continueFilter = false;
                try
                {
                    xmlStream = new StreamWriter(outputStream);
                    using (var reader = XmlReader.Create(inputStream))
                    {

                        using (
                            var writer = XmlWriter.Create(xmlStream,
                                new XmlWriterSettings() { ConformanceLevel = ConformanceLevel.Auto }))
                        {
                            while (reader.Read())
                            {
                                
                                if (reader.LocalName.Equals("SignatureConfirmation") &&
                                    reader.NamespaceURI.Equals(
                                        "http://docs.oasis-open.org/wss/oasis-wss-wssecurity-secext-1.1.xsd"))
                                {
                                    if (!reader.IsEmptyElement)
                                    {
                                        continueFilter = reader.IsStartElement();
                                    }
                                }
                                /*else if (reader.LocalName.Equals("Signature") && reader.NamespaceURI.Equals("http://www.w3.org/2000/09/xmldsig#"))
                                {
                                    if (!reader.IsEmptyElement)
                                    {
                                        continueFilter = reader.IsStartElement();
                                    }
                                }*/
                                else if (reader.LocalName.Equals("Timestamp") && reader.NamespaceURI.Equals("http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"))
                                {
                                    if (!reader.IsEmptyElement)
                                    {
                                        continueFilter = reader.IsStartElement();
                                    }
                                }
                                else if (continueFilter)
                                {
                                    if (!reader.IsEmptyElement && reader.LocalName != "Transforms")
                                    {
                                        continueFilter = reader.IsStartElement();
                                    }
                                    //Console.WriteLine("skipping:" + reader.Name);
                                    // continue to next node
                                }
                                else
                                {
                                    if (reader.LocalName.Equals("Reference") && reader.HasAttributes)
                                    {
                                        bool shouldIgnore = false;
                                        for (int attInd = 0; attInd < reader.AttributeCount; attInd++)
                                        {
                                            reader.MoveToAttribute(attInd);
                                            foreach (string s in referenceList)
                                            {
                                                if (reader.Name == "URI" && reader.Value == "#" + s)
                                                {
                                                    // continueFilter = reader.IsStartElement();
                                                    shouldIgnore = true;
                                                    if (!reader.IsEmptyElement)
                                                    {
                                                        continueFilter = reader.IsStartElement();
                                                    }
                                                }
                                                else
                                                {
                                                    
                                                }
                                                
                                            }
                                        }
                                        // Move the reader back to the element node.
                                        reader.MoveToElement();
                                        if (!shouldIgnore)
                                        {
                                            Console.WriteLine(reader.Name);
                                            XmlHelper.WriteShallowNode(reader, writer);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine(reader.Name);
                                        XmlHelper.WriteShallowNode(reader, writer);
                                    }
                                }
                            }
                            writer.Flush();
                        }
                        reader.Close();
                    }
                    outputStream.Position = 0;
                    inputStream.Position = 0;
                    return outputStream;
                }
                catch (Exception ex)
                {
                    // handle error
                    throw;
                }
                finally
                {
                    if (xmlStream != null && dispose) xmlStream.Dispose();
                }
            }

            

        }
    }
}
