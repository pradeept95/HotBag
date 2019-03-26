using System;

namespace HotBag.Autofill.Attribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class AutoFillAttribute : System.Attribute
    {
        public object DefaultValue;
        public bool HasFixedValue = false;

        public AutoFillAttribute(object value) 
        {
            DefaultValue = value;
            HasFixedValue = true;
        }

        public AutoFillProperty fillBy;
        public AutoFillAttribute(AutoFillProperty autofillby) 
        {
            fillBy = autofillby;
        }
    }

    public enum AutoFillProperty
    {
        PrimaryKey,
        CurrentDate,
        CurrentUser,
        CurrentCulture,
        CurrentTanent
    }
}