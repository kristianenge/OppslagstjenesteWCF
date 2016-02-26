using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
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
                return this._text.ReadMessage(ProcessMemoryStream(stream, false), maxSizeOfHeaders, contentType);
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

            private MemoryStream ProcessMemoryStream(Stream inputStream, bool dispose)
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
                                else if (reader.LocalName.Equals("Signature") && reader.NamespaceURI.Equals("http://www.w3.org/2000/09/xmldsig#"))
                                {
                                    if (!reader.IsEmptyElement)
                                    {
                                        continueFilter = reader.IsStartElement();
                                    }
                                }
                                else if (reader.LocalName.Equals("Timestamp") && reader.NamespaceURI.Equals("http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"))
                                {
                                    if (!reader.IsEmptyElement)
                                    {
                                        continueFilter = reader.IsStartElement();
                                    }
                                }
                                else if (continueFilter)
                                {
                                    // continue to next node
                                }
                                else
                                {
                                    XmlHelper.WriteShallowNode(reader, writer);
                                }
                            }
                            writer.Flush();
                        }
                        reader.Close();
                    }
                    outputStream.Position = 0;
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
