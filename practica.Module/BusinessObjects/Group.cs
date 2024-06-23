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
    
    public class Group : XPCustomObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public Group(Session session)
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

            for (int i = this.Students.Count - 1; i >= 0; --i)
            {
                this.Students[i].Group = null;
            }
        }

        int groupId;
        EducationalProgram educationalProgram;
        string shortName;
        string name;


        [Size(SizeAttribute.DefaultStringMappingFieldSize), RuleRequiredField, RuleUniqueValue]
        public string ShortName
        {
            get => shortName;
            set => SetPropertyValue(nameof(ShortName), ref shortName, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize), RuleRequiredField]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }


        [Association("EducationalProgram-Groups")]
        public EducationalProgram EducationalProgram
        {
            get => educationalProgram;
            set => SetPropertyValue(nameof(EducationalProgram), ref educationalProgram, value);
        }

        [Key]
        public int GroupId
        {
            get => groupId;
            set => SetPropertyValue(nameof(GroupId), ref groupId, value);
        }

        [Association("Group-Students")]
        public XPCollection<Student> Students
        {
            get
            {
                return GetCollection<Student>(nameof(Students));
            }
        }
    }
}