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
    public class EducationalProgram : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public EducationalProgram(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        protected override void OnDeleting()
        {
            base.OnDeleting();

            for (int i = this.Groups.Count - 1; i >= 0; --i)
            {
                this.Groups[i].EducationalProgram = null;
            }
        }

        string educationalProgramCode;
        string profile;
        string level;
        string name;

        
        [Size(SizeAttribute.DefaultStringMappingFieldSize), RuleUniqueValue, RuleRequiredField]
        public string EducationalProgramCode
        {
            get => educationalProgramCode;
            set => SetPropertyValue(nameof(EducationalProgramCode), ref educationalProgramCode, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize), RuleRequiredField]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize), RuleRequiredField]
        public string Level
        {
            get => level;
            set => SetPropertyValue(nameof(Level), ref level, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize), RuleRequiredField]
        public string Profile
        {
            get => profile;
            set => SetPropertyValue(nameof(Profile), ref profile, value);
        }

        [Association("EducationalProgram-Groups")]
        public XPCollection<Group> Groups
        {
            get
            {
                return GetCollection<Group>(nameof(Groups));
            }
        }
    }
}