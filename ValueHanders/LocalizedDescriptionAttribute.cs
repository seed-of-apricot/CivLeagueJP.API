using System;
using System.ComponentModel;
using System.Reflection;
using System.Resources;

namespace CivLeagueJP.API.ValueHandlers
{
    /// <summary>
    /// Enum Localization.
    /// Referenced from stackoverflow.com.
    /// Referred: https://stackoverflow.com/questions/17380900
    /// Author: eluxen(https://stackoverflow.com/users/1941360)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LocalizedDescriptionAttribute : DescriptionAttribute
    {
        private string resourceKey;
        private ResourceManager resourceManager;

        public LocalizedDescriptionAttribute(string _resourceKey, Type _resourceType)
        {
            resourceManager = new ResourceManager(_resourceType);
            resourceKey = _resourceKey;
        }

        public override string Description
        {
            get
            {
                string str = resourceManager.GetString(resourceKey);
                return string.IsNullOrEmpty(str) ? string.Empty : str;
            }
        }
    }

    /// <summary>
    /// Enum Localization.
    /// Referenced from stackoverflow.com.
    /// Referred: https://stackoverflow.com/questions/17380900
    /// Author: eluxen(https://stackoverflow.com/users/1941360)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class EnumExtensions
    {
        public static string GetDescription(Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] descriptionAttribute =
                (DescriptionAttribute[])fieldInfo.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (descriptionAttribute.Length > 0)
            {
                return descriptionAttribute[0].Description;

            }
            else
            {
                return string.Empty;
            }
        }
    }
}

