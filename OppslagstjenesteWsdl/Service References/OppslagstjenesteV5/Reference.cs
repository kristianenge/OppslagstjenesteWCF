﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OppslagstjenesteWsdl.OppslagstjenesteV5 {

    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
/*    [System.ServiceModel.ServiceContractAttribute(Name="oppslagstjeneste-16-02", Namespace="http://kontaktinfo.difi.no/wsdl/oppslagstjeneste-16-02", ConfigurationName="OppslagstjenesteV5.oppslagstjeneste1602", ProtectionLevel = System.Net.Security.ProtectionLevel.Sign)]*/
    [System.ServiceModel.ServiceContractAttribute(Name = "oppslagstjeneste-16-02", Namespace = "http://kontaktinfo.difi.no/wsdl/oppslagstjeneste-16-02", ConfigurationName = "OppslagstjenesteV5.oppslagstjeneste1602")]
    public interface oppslagstjeneste1602 {
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        OppslagstjenesteWsdl.OppslagstjenesteV5.HentEndringerResponse HentEndringer(OppslagstjenesteWsdl.OppslagstjenesteV5.HentEndringerRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<OppslagstjenesteWsdl.OppslagstjenesteV5.HentEndringerResponse> HentEndringerAsync(OppslagstjenesteWsdl.OppslagstjenesteV5.HentEndringerRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        OppslagstjenesteWsdl.OppslagstjenesteV5.HentPersonerResponse HentPersoner(OppslagstjenesteWsdl.OppslagstjenesteV5.HentPersonerRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<OppslagstjenesteWsdl.OppslagstjenesteV5.HentPersonerResponse> HentPersonerAsync(OppslagstjenesteWsdl.OppslagstjenesteV5.HentPersonerRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        OppslagstjenesteWsdl.OppslagstjenesteV5.HentPrintSertifikatResponse HentPrintSertifikat(OppslagstjenesteWsdl.OppslagstjenesteV5.HentPrintSertifikatRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<OppslagstjenesteWsdl.OppslagstjenesteV5.HentPrintSertifikatResponse> HentPrintSertifikatAsync(OppslagstjenesteWsdl.OppslagstjenesteV5.HentPrintSertifikatRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://kontaktinfo.difi.no/xsd/oppslagstjeneste/16-02")]
    public partial class Oppslagstjenesten : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string paaVegneAvField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string PaaVegneAv {
            get {
                return this.paaVegneAvField;
            }
            set {
                this.paaVegneAvField = value;
                this.RaisePropertyChanged("PaaVegneAv");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://begrep.difi.no")]
    public partial class SikkerDigitalPostAdresse : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string postkasseadresseField;
        
        private string postkasseleverandoerAdresseField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string postkasseadresse {
            get {
                return this.postkasseadresseField;
            }
            set {
                this.postkasseadresseField = value;
                this.RaisePropertyChanged("postkasseadresse");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string postkasseleverandoerAdresse {
            get {
                return this.postkasseleverandoerAdresseField;
            }
            set {
                this.postkasseleverandoerAdresseField = value;
                this.RaisePropertyChanged("postkasseleverandoerAdresse");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://begrep.difi.no")]
    public partial class Epostadresse : object, System.ComponentModel.INotifyPropertyChanged {
        
        private System.DateTime sistOppdatertField;
        
        private bool sistOppdatertFieldSpecified;
        
        private System.DateTime sistVerifisertField;
        
        private bool sistVerifisertFieldSpecified;
        
        private string valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime sistOppdatert {
            get {
                return this.sistOppdatertField;
            }
            set {
                this.sistOppdatertField = value;
                this.RaisePropertyChanged("sistOppdatert");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool sistOppdatertSpecified {
            get {
                return this.sistOppdatertFieldSpecified;
            }
            set {
                this.sistOppdatertFieldSpecified = value;
                this.RaisePropertyChanged("sistOppdatertSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime sistVerifisert {
            get {
                return this.sistVerifisertField;
            }
            set {
                this.sistVerifisertField = value;
                this.RaisePropertyChanged("sistVerifisert");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool sistVerifisertSpecified {
            get {
                return this.sistVerifisertFieldSpecified;
            }
            set {
                this.sistVerifisertFieldSpecified = value;
                this.RaisePropertyChanged("sistVerifisertSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
                this.RaisePropertyChanged("Value");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://begrep.difi.no")]
    public partial class Mobiltelefonnummer : object, System.ComponentModel.INotifyPropertyChanged {
        
        private System.DateTime sistOppdatertField;
        
        private bool sistOppdatertFieldSpecified;
        
        private System.DateTime sistVerifisertField;
        
        private bool sistVerifisertFieldSpecified;
        
        private string valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime sistOppdatert {
            get {
                return this.sistOppdatertField;
            }
            set {
                this.sistOppdatertField = value;
                this.RaisePropertyChanged("sistOppdatert");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool sistOppdatertSpecified {
            get {
                return this.sistOppdatertFieldSpecified;
            }
            set {
                this.sistOppdatertFieldSpecified = value;
                this.RaisePropertyChanged("sistOppdatertSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime sistVerifisert {
            get {
                return this.sistVerifisertField;
            }
            set {
                this.sistVerifisertField = value;
                this.RaisePropertyChanged("sistVerifisert");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool sistVerifisertSpecified {
            get {
                return this.sistVerifisertFieldSpecified;
            }
            set {
                this.sistVerifisertFieldSpecified = value;
                this.RaisePropertyChanged("sistVerifisertSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
                this.RaisePropertyChanged("Value");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://begrep.difi.no")]
    public partial class Kontaktinformasjon : object, System.ComponentModel.INotifyPropertyChanged {
        
        private Mobiltelefonnummer mobiltelefonnummerField;
        
        private Epostadresse epostadresseField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public Mobiltelefonnummer Mobiltelefonnummer {
            get {
                return this.mobiltelefonnummerField;
            }
            set {
                this.mobiltelefonnummerField = value;
                this.RaisePropertyChanged("Mobiltelefonnummer");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public Epostadresse Epostadresse {
            get {
                return this.epostadresseField;
            }
            set {
                this.epostadresseField = value;
                this.RaisePropertyChanged("Epostadresse");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://begrep.difi.no")]
    public partial class Person : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string personidentifikatorField;
        
        private reservasjon reservasjonField;
        
        private bool reservasjonFieldSpecified;
        
        private status statusField;
        
        private bool statusFieldSpecified;
        
        private varslingsstatus varslingsstatusField;
        
        private bool varslingsstatusFieldSpecified;
        
        private Kontaktinformasjon kontaktinformasjonField;
        
        private SikkerDigitalPostAdresse sikkerDigitalPostAdresseField;
        
        private byte[] x509SertifikatField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string personidentifikator {
            get {
                return this.personidentifikatorField;
            }
            set {
                this.personidentifikatorField = value;
                this.RaisePropertyChanged("personidentifikator");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public reservasjon reservasjon {
            get {
                return this.reservasjonField;
            }
            set {
                this.reservasjonField = value;
                this.RaisePropertyChanged("reservasjon");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool reservasjonSpecified {
            get {
                return this.reservasjonFieldSpecified;
            }
            set {
                this.reservasjonFieldSpecified = value;
                this.RaisePropertyChanged("reservasjonSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public status status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
                this.RaisePropertyChanged("status");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool statusSpecified {
            get {
                return this.statusFieldSpecified;
            }
            set {
                this.statusFieldSpecified = value;
                this.RaisePropertyChanged("statusSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public varslingsstatus varslingsstatus {
            get {
                return this.varslingsstatusField;
            }
            set {
                this.varslingsstatusField = value;
                this.RaisePropertyChanged("varslingsstatus");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool varslingsstatusSpecified {
            get {
                return this.varslingsstatusFieldSpecified;
            }
            set {
                this.varslingsstatusFieldSpecified = value;
                this.RaisePropertyChanged("varslingsstatusSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public Kontaktinformasjon Kontaktinformasjon {
            get {
                return this.kontaktinformasjonField;
            }
            set {
                this.kontaktinformasjonField = value;
                this.RaisePropertyChanged("Kontaktinformasjon");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public SikkerDigitalPostAdresse SikkerDigitalPostAdresse {
            get {
                return this.sikkerDigitalPostAdresseField;
            }
            set {
                this.sikkerDigitalPostAdresseField = value;
                this.RaisePropertyChanged("SikkerDigitalPostAdresse");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary", Order=6)]
        public byte[] X509Sertifikat {
            get {
                return this.x509SertifikatField;
            }
            set {
                this.x509SertifikatField = value;
                this.RaisePropertyChanged("X509Sertifikat");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://begrep.difi.no")]
    public enum reservasjon {
        
        /// <remarks/>
        JA,
        
        /// <remarks/>
        NEI,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://begrep.difi.no")]
    public enum status {
        
        /// <remarks/>
        AKTIV,
        
        /// <remarks/>
        SLETTET,
        
        /// <remarks/>
        IKKE_REGISTRERT,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://begrep.difi.no")]
    public enum varslingsstatus {
        
        /// <remarks/>
        KAN_IKKE_VARSLES,
        
        /// <remarks/>
        KAN_VARSLES,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://kontaktinfo.difi.no/xsd/oppslagstjeneste/16-02")]
    public partial class HentEndringerForespoersel : object, System.ComponentModel.INotifyPropertyChanged {
        
        private informasjonsbehov[] informasjonsbehovField;
        
        private long fraEndringsNummerField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("informasjonsbehov", Order=0)]
        public informasjonsbehov[] informasjonsbehov {
            get {
                return this.informasjonsbehovField;
            }
            set {
                this.informasjonsbehovField = value;
                this.RaisePropertyChanged("informasjonsbehov");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public long fraEndringsNummer {
            get {
                return this.fraEndringsNummerField;
            }
            set {
                this.fraEndringsNummerField = value;
                this.RaisePropertyChanged("fraEndringsNummer");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://kontaktinfo.difi.no/xsd/oppslagstjeneste/16-02")]
    public enum informasjonsbehov {
        
        /// <remarks/>
        Person,
        
        /// <remarks/>
        Kontaktinfo,
        
        /// <remarks/>
        Sertifikat,
        
        /// <remarks/>
        SikkerDigitalPost,
        
        /// <remarks/>
        VarslingsStatus,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://kontaktinfo.difi.no/xsd/oppslagstjeneste/16-02")]
    public partial class HentEndringerRespons : object, System.ComponentModel.INotifyPropertyChanged {
        
        private Person[] personField;
        
        private long fraEndringsNummerField;
        
        private long tilEndringsNummerField;
        
        private long senesteEndringsNummerField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Person", Namespace="http://begrep.difi.no", Order=0)]
        public Person[] Person {
            get {
                return this.personField;
            }
            set {
                this.personField = value;
                this.RaisePropertyChanged("Person");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public long fraEndringsNummer {
            get {
                return this.fraEndringsNummerField;
            }
            set {
                this.fraEndringsNummerField = value;
                this.RaisePropertyChanged("fraEndringsNummer");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public long tilEndringsNummer {
            get {
                return this.tilEndringsNummerField;
            }
            set {
                this.tilEndringsNummerField = value;
                this.RaisePropertyChanged("tilEndringsNummer");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public long senesteEndringsNummer {
            get {
                return this.senesteEndringsNummerField;
            }
            set {
                this.senesteEndringsNummerField = value;
                this.RaisePropertyChanged("senesteEndringsNummer");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HentEndringerRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://kontaktinfo.difi.no/xsd/oppslagstjeneste/16-02")]
        public OppslagstjenesteWsdl.OppslagstjenesteV5.Oppslagstjenesten Oppslagstjenesten;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://kontaktinfo.difi.no/xsd/oppslagstjeneste/16-02", Order=0)]
        public OppslagstjenesteWsdl.OppslagstjenesteV5.HentEndringerForespoersel HentEndringerForespoersel;
        
        public HentEndringerRequest() {
        }
        
        public HentEndringerRequest(OppslagstjenesteWsdl.OppslagstjenesteV5.Oppslagstjenesten Oppslagstjenesten, OppslagstjenesteWsdl.OppslagstjenesteV5.HentEndringerForespoersel HentEndringerForespoersel) {
            this.Oppslagstjenesten = Oppslagstjenesten;
            this.HentEndringerForespoersel = HentEndringerForespoersel;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HentEndringerResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://kontaktinfo.difi.no/xsd/oppslagstjeneste/16-02", Order=0)]
        public OppslagstjenesteWsdl.OppslagstjenesteV5.HentEndringerRespons HentEndringerRespons;
        
        public HentEndringerResponse() {
        }
        
        public HentEndringerResponse(OppslagstjenesteWsdl.OppslagstjenesteV5.HentEndringerRespons HentEndringerRespons) {
            this.HentEndringerRespons = HentEndringerRespons;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://kontaktinfo.difi.no/xsd/oppslagstjeneste/16-02")]
    public partial class HentPersonerForespoersel : object, System.ComponentModel.INotifyPropertyChanged {
        
        private informasjonsbehov[] informasjonsbehovField;
        
        private string[] personidentifikatorField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("informasjonsbehov", Order=0)]
        public informasjonsbehov[] informasjonsbehov {
            get {
                return this.informasjonsbehovField;
            }
            set {
                this.informasjonsbehovField = value;
                this.RaisePropertyChanged("informasjonsbehov");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("personidentifikator", Order=1)]
        public string[] personidentifikator {
            get {
                return this.personidentifikatorField;
            }
            set {
                this.personidentifikatorField = value;
                this.RaisePropertyChanged("personidentifikator");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HentPersonerRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://kontaktinfo.difi.no/xsd/oppslagstjeneste/16-02")]
        public OppslagstjenesteWsdl.OppslagstjenesteV5.Oppslagstjenesten Oppslagstjenesten;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://kontaktinfo.difi.no/xsd/oppslagstjeneste/16-02", Order=0)]
        public OppslagstjenesteWsdl.OppslagstjenesteV5.HentPersonerForespoersel HentPersonerForespoersel;
        
        public HentPersonerRequest() {
        }
        
        public HentPersonerRequest(OppslagstjenesteWsdl.OppslagstjenesteV5.Oppslagstjenesten Oppslagstjenesten, OppslagstjenesteWsdl.OppslagstjenesteV5.HentPersonerForespoersel HentPersonerForespoersel) {
            this.Oppslagstjenesten = Oppslagstjenesten;
            this.HentPersonerForespoersel = HentPersonerForespoersel;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HentPersonerResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://kontaktinfo.difi.no/xsd/oppslagstjeneste/16-02", Order=0)]
        [System.Xml.Serialization.XmlArrayItemAttribute(Namespace="http://begrep.difi.no", IsNullable=false)]
        public OppslagstjenesteWsdl.OppslagstjenesteV5.Person[] HentPersonerRespons;
        
        public HentPersonerResponse() {
        }
        
        public HentPersonerResponse(OppslagstjenesteWsdl.OppslagstjenesteV5.Person[] HentPersonerRespons) {
            this.HentPersonerRespons = HentPersonerRespons;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://kontaktinfo.difi.no/xsd/oppslagstjeneste/16-02")]
    public partial class HentPrintSertifikatForespoersel : object, System.ComponentModel.INotifyPropertyChanged {
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://kontaktinfo.difi.no/xsd/oppslagstjeneste/16-02")]
    public partial class HentPrintSertifikatRespons : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string postkasseleverandoerAdresseField;
        
        private byte[] x509SertifikatField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string postkasseleverandoerAdresse {
            get {
                return this.postkasseleverandoerAdresseField;
            }
            set {
                this.postkasseleverandoerAdresseField = value;
                this.RaisePropertyChanged("postkasseleverandoerAdresse");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary", Order=1)]
        public byte[] X509Sertifikat {
            get {
                return this.x509SertifikatField;
            }
            set {
                this.x509SertifikatField = value;
                this.RaisePropertyChanged("X509Sertifikat");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HentPrintSertifikatRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://kontaktinfo.difi.no/xsd/oppslagstjeneste/16-02")]
        public OppslagstjenesteWsdl.OppslagstjenesteV5.Oppslagstjenesten Oppslagstjenesten;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://kontaktinfo.difi.no/xsd/oppslagstjeneste/16-02", Order=0)]
        public OppslagstjenesteWsdl.OppslagstjenesteV5.HentPrintSertifikatForespoersel HentPrintSertifikatForespoersel;
        
        public HentPrintSertifikatRequest() {
        }
        
        public HentPrintSertifikatRequest(OppslagstjenesteWsdl.OppslagstjenesteV5.Oppslagstjenesten Oppslagstjenesten, OppslagstjenesteWsdl.OppslagstjenesteV5.HentPrintSertifikatForespoersel HentPrintSertifikatForespoersel) {
            this.Oppslagstjenesten = Oppslagstjenesten;
            this.HentPrintSertifikatForespoersel = HentPrintSertifikatForespoersel;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HentPrintSertifikatResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://kontaktinfo.difi.no/xsd/oppslagstjeneste/16-02", Order=0)]
        public OppslagstjenesteWsdl.OppslagstjenesteV5.HentPrintSertifikatRespons HentPrintSertifikatRespons;
        
        public HentPrintSertifikatResponse() {
        }
        
        public HentPrintSertifikatResponse(OppslagstjenesteWsdl.OppslagstjenesteV5.HentPrintSertifikatRespons HentPrintSertifikatRespons) {
            this.HentPrintSertifikatRespons = HentPrintSertifikatRespons;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface oppslagstjeneste1602Channel : OppslagstjenesteWsdl.OppslagstjenesteV5.oppslagstjeneste1602, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class oppslagstjeneste1602Client : System.ServiceModel.ClientBase<OppslagstjenesteWsdl.OppslagstjenesteV5.oppslagstjeneste1602>, OppslagstjenesteWsdl.OppslagstjenesteV5.oppslagstjeneste1602 {
        
        public oppslagstjeneste1602Client() {
        }
        
        public oppslagstjeneste1602Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public oppslagstjeneste1602Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public oppslagstjeneste1602Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public oppslagstjeneste1602Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public OppslagstjenesteWsdl.OppslagstjenesteV5.HentEndringerResponse HentEndringer(OppslagstjenesteWsdl.OppslagstjenesteV5.HentEndringerRequest request) {
            return base.Channel.HentEndringer(request);
        }
        
        public System.Threading.Tasks.Task<OppslagstjenesteWsdl.OppslagstjenesteV5.HentEndringerResponse> HentEndringerAsync(OppslagstjenesteWsdl.OppslagstjenesteV5.HentEndringerRequest request) {
            return base.Channel.HentEndringerAsync(request);
        }
        
        public OppslagstjenesteWsdl.OppslagstjenesteV5.HentPersonerResponse HentPersoner(OppslagstjenesteWsdl.OppslagstjenesteV5.HentPersonerRequest request) {
            return base.Channel.HentPersoner(request);
        }
        
        public System.Threading.Tasks.Task<OppslagstjenesteWsdl.OppslagstjenesteV5.HentPersonerResponse> HentPersonerAsync(OppslagstjenesteWsdl.OppslagstjenesteV5.HentPersonerRequest request) {
            return base.Channel.HentPersonerAsync(request);
        }
        
        public OppslagstjenesteWsdl.OppslagstjenesteV5.HentPrintSertifikatResponse HentPrintSertifikat(OppslagstjenesteWsdl.OppslagstjenesteV5.HentPrintSertifikatRequest request) {
            return base.Channel.HentPrintSertifikat(request);
        }
        
        public System.Threading.Tasks.Task<OppslagstjenesteWsdl.OppslagstjenesteV5.HentPrintSertifikatResponse> HentPrintSertifikatAsync(OppslagstjenesteWsdl.OppslagstjenesteV5.HentPrintSertifikatRequest request) {
            return base.Channel.HentPrintSertifikatAsync(request);
        }
    }
}