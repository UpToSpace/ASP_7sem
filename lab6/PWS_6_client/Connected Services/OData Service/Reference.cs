﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

// Original file name:
// Generation date: 21.11.2023 15:23:50
namespace WSKVSModel
{
    
    /// <summary>
    /// There are no comments for WSKVSEntities in the schema.
    /// </summary>
    public partial class WSKVSEntities : global::System.Data.Services.Client.DataServiceContext
    {
        /// <summary>
        /// Initialize a new WSKVSEntities object.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public WSKVSEntities(global::System.Uri serviceRoot) : 
                base(serviceRoot, global::System.Data.Services.Common.DataServiceProtocolVersion.V3)
        {
            this.OnContextCreated();
            this.Format.LoadServiceModel = GeneratedEdmModel.GetInstance;
        }
        partial void OnContextCreated();
        /// <summary>
        /// There are no comments for Note in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<Note> Note
        {
            get
            {
                if ((this._Note == null))
                {
                    this._Note = base.CreateQuery<Note>("Note");
                }
                return this._Note;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<Note> _Note;
        /// <summary>
        /// There are no comments for Student in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<Student> Student
        {
            get
            {
                if ((this._Student == null))
                {
                    this._Student = base.CreateQuery<Student>("Student");
                }
                return this._Student;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<Student> _Student;
        /// <summary>
        /// There are no comments for Note in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToNote(Note note)
        {
            base.AddObject("Note", note);
        }
        /// <summary>
        /// There are no comments for Student in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToStudent(Student student)
        {
            base.AddObject("Student", student);
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private abstract class GeneratedEdmModel
        {
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
            private static global::Microsoft.Data.Edm.IEdmModel ParsedModel = LoadModelFromString();
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
            private const string ModelPart0 = "<edmx:Edmx Version=\"1.0\" xmlns:edmx=\"http://schemas.microsoft.com/ado/2007/06/edm" +
                "x\"><edmx:DataServices m:DataServiceVersion=\"1.0\" m:MaxDataServiceVersion=\"3.0\" x" +
                "mlns:m=\"http://schemas.microsoft.com/ado/2007/08/dataservices/metadata\"><Schema " +
                "Namespace=\"WSKVSModel\" xmlns=\"http://schemas.microsoft.com/ado/2009/11/edm\"><Ent" +
                "ityType Name=\"Note\"><Key><PropertyRef Name=\"id\" /></Key><Property Name=\"id\" Type" +
                "=\"Edm.Int32\" Nullable=\"false\" p6:StoreGeneratedPattern=\"Identity\" xmlns:p6=\"http" +
                "://schemas.microsoft.com/ado/2009/02/edm/annotation\" /><Property Name=\"student_i" +
                "d\" Type=\"Edm.Int32\" Nullable=\"false\" /><Property Name=\"subject\" Type=\"Edm.String" +
                "\" Nullable=\"false\" MaxLength=\"255\" FixedLength=\"false\" Unicode=\"false\" /><Proper" +
                "ty Name=\"note1\" Type=\"Edm.Int32\" /><NavigationProperty Name=\"Student\" Relationsh" +
                "ip=\"WSKVSModel.FK__Note__student_id__398D8EEE\" ToRole=\"Student\" FromRole=\"Note\" " +
                "/></EntityType><EntityType Name=\"Student\"><Key><PropertyRef Name=\"id\" /></Key><P" +
                "roperty Name=\"id\" Type=\"Edm.Int32\" Nullable=\"false\" p6:StoreGeneratedPattern=\"Id" +
                "entity\" xmlns:p6=\"http://schemas.microsoft.com/ado/2009/02/edm/annotation\" /><Pr" +
                "operty Name=\"name\" Type=\"Edm.String\" Nullable=\"false\" MaxLength=\"255\" FixedLengt" +
                "h=\"false\" Unicode=\"false\" /><NavigationProperty Name=\"Note\" Relationship=\"WSKVSM" +
                "odel.FK__Note__student_id__398D8EEE\" ToRole=\"Note\" FromRole=\"Student\" /></Entity" +
                "Type><Association Name=\"FK__Note__student_id__398D8EEE\"><End Type=\"WSKVSModel.St" +
                "udent\" Role=\"Student\" Multiplicity=\"1\" /><End Type=\"WSKVSModel.Note\" Role=\"Note\"" +
                " Multiplicity=\"*\" /><ReferentialConstraint><Principal Role=\"Student\"><PropertyRe" +
                "f Name=\"id\" /></Principal><Dependent Role=\"Note\"><PropertyRef Name=\"student_id\" " +
                "/></Dependent></ReferentialConstraint></Association></Schema><Schema Namespace=\"" +
                "MVC.Edmx\" xmlns=\"http://schemas.microsoft.com/ado/2009/11/edm\"><EntityContainer " +
                "Name=\"WSKVSEntities\" m:IsDefaultEntityContainer=\"true\"><EntitySet Name=\"Note\" En" +
                "tityType=\"WSKVSModel.Note\" /><EntitySet Name=\"Student\" EntityType=\"WSKVSModel.St" +
                "udent\" /><AssociationSet Name=\"FK__Note__student_id__398D8EEE\" Association=\"WSKV" +
                "SModel.FK__Note__student_id__398D8EEE\"><End Role=\"Note\" EntitySet=\"Note\" /><End " +
                "Role=\"Student\" EntitySet=\"Student\" /></AssociationSet></EntityContainer></Schema" +
                "></edmx:DataServices></edmx:Edmx>";
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
            private static string GetConcatenatedEdmxString()
            {
                return string.Concat(ModelPart0);
            }
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
            public static global::Microsoft.Data.Edm.IEdmModel GetInstance()
            {
                return ParsedModel;
            }
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
            private static global::Microsoft.Data.Edm.IEdmModel LoadModelFromString()
            {
                string edmxToParse = GetConcatenatedEdmxString();
                global::System.Xml.XmlReader reader = CreateXmlReader(edmxToParse);
                try
                {
                    return global::Microsoft.Data.Edm.Csdl.EdmxReader.Parse(reader);
                }
                finally
                {
                    ((global::System.IDisposable)(reader)).Dispose();
                }
            }
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
            private static global::System.Xml.XmlReader CreateXmlReader(string edmxToParse)
            {
                return global::System.Xml.XmlReader.Create(new global::System.IO.StringReader(edmxToParse));
            }
        }
    }
    /// <summary>
    /// There are no comments for WSKVSModel.Note in the schema.
    /// </summary>
    /// <KeyProperties>
    /// id
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("Note")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("id")]
    public partial class Note : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new Note object.
        /// </summary>
        /// <param name="ID">Initial value of id.</param>
        /// <param name="student_id">Initial value of student_id.</param>
        /// <param name="subject">Initial value of subject.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static Note CreateNote(int ID, int student_id, string subject)
        {
            Note note = new Note();
            note.id = ID;
            note.student_id = student_id;
            note.subject = subject;
            return note;
        }
        /// <summary>
        /// There are no comments for Property id in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                this.OnidChanging(value);
                this._id = value;
                this.OnidChanged();
                this.OnPropertyChanged("id");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _id;
        partial void OnidChanging(int value);
        partial void OnidChanged();
        /// <summary>
        /// There are no comments for Property student_id in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int student_id
        {
            get
            {
                return this._student_id;
            }
            set
            {
                this.Onstudent_idChanging(value);
                this._student_id = value;
                this.Onstudent_idChanged();
                this.OnPropertyChanged("student_id");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _student_id;
        partial void Onstudent_idChanging(int value);
        partial void Onstudent_idChanged();
        /// <summary>
        /// There are no comments for Property subject in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string subject
        {
            get
            {
                return this._subject;
            }
            set
            {
                this.OnsubjectChanging(value);
                this._subject = value;
                this.OnsubjectChanged();
                this.OnPropertyChanged("subject");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _subject;
        partial void OnsubjectChanging(string value);
        partial void OnsubjectChanged();
        /// <summary>
        /// There are no comments for Property note1 in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<int> note1
        {
            get
            {
                return this._note1;
            }
            set
            {
                this.Onnote1Changing(value);
                this._note1 = value;
                this.Onnote1Changed();
                this.OnPropertyChanged("note1");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<int> _note1;
        partial void Onnote1Changing(global::System.Nullable<int> value);
        partial void Onnote1Changed();
        /// <summary>
        /// There are no comments for Student in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public Student Student
        {
            get
            {
                return this._Student;
            }
            set
            {
                this._Student = value;
                this.OnPropertyChanged("Student");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private Student _Student;
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
    /// <summary>
    /// There are no comments for WSKVSModel.Student in the schema.
    /// </summary>
    /// <KeyProperties>
    /// id
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("Student")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("id")]
    public partial class Student : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new Student object.
        /// </summary>
        /// <param name="ID">Initial value of id.</param>
        /// <param name="name">Initial value of name.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static Student CreateStudent(int ID, string name)
        {
            Student student = new Student();
            student.id = ID;
            student.name = name;
            return student;
        }
        /// <summary>
        /// There are no comments for Property id in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                this.OnidChanging(value);
                this._id = value;
                this.OnidChanged();
                this.OnPropertyChanged("id");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _id;
        partial void OnidChanging(int value);
        partial void OnidChanged();
        /// <summary>
        /// There are no comments for Property name in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string name
        {
            get
            {
                return this._name;
            }
            set
            {
                this.OnnameChanging(value);
                this._name = value;
                this.OnnameChanged();
                this.OnPropertyChanged("name");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _name;
        partial void OnnameChanging(string value);
        partial void OnnameChanged();
        /// <summary>
        /// There are no comments for Note in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceCollection<Note> Note
        {
            get
            {
                return this._Note;
            }
            set
            {
                this._Note = value;
                this.OnPropertyChanged("Note");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceCollection<Note> _Note = new global::System.Data.Services.Client.DataServiceCollection<Note>(null, global::System.Data.Services.Client.TrackingMode.None);
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
}
