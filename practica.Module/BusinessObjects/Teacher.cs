using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace practica.Module.BusinessObjects
{
    [DefaultClassOptions, DeferredDeletion(false)]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Teacher : XPCustomObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public Teacher(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        byte[] photo;
        Department department;
        int teacherId;
        string mail;
        string phoneNomber;
        string fullName;

        [Size(SizeAttribute.DefaultStringMappingFieldSize), RuleRequiredField]
        public string FullName
        {
            get => fullName;
            set => SetPropertyValue(nameof(FullName), ref fullName, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize), RuleRegularExpression("^((8|\\+7)[\\- ]?)?(\\(?\\d{3}\\)?[\\- ]?)?[\\d\\- ]{7,10}$", CustomMessageTemplate = "Enter correct phone nomber")]
        public string PhoneNomber
        {
            get => phoneNomber;
            set => SetPropertyValue(nameof(PhoneNomber), ref phoneNomber, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize), RuleRequiredField, RuleRegularExpression("[\\s\\S]+@[\\s\\S]+\\.[\\s\\S]", CustomMessageTemplate = "Enter correct email")]
        public string Mail
        {
            get => mail;
            set => SetPropertyValue(nameof(Mail), ref mail, value);
        }


        [Key(true)]
        public int TeacherId
        {
            get => teacherId;
            set => SetPropertyValue(nameof(TeacherId), ref teacherId, value);
        }


        [Association("Department-Teachers")]
        public Department Department
        {
            get => department;
            set => SetPropertyValue(nameof(Department), ref department, value);
        }

        [ImageEditor(DetailViewImageEditorFixedHeight = 200, ListViewImageEditorCustomHeight = 100)]
        public byte[] Photo
        {
            get => photo;
            set => SetPropertyValue(nameof(Photo), ref photo, value);
        }
    }
}