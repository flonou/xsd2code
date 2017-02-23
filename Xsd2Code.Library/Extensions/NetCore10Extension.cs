using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xsd2Code.Library.Extensions
{
    /// <summary>
    /// Implements code extension for .Net Core 1.0
    /// </summary>
    [CodeExtension(TargetFramework.NetCore10)]
    public class NetCore10Extension : Net35Extension
    {

        /// <summary>
        /// Removes unsupported attributes.
        /// </summary>
        /// <param name="customAttributes">
        /// The custom Attributes.
        /// </param>
        protected override void RemoveUnsupportedXmlAttributes(CodeAttributeDeclarationCollection customAttributes)
        {
            var codeAttributes = new List<CodeAttributeDeclaration>();
            foreach (var attribute in customAttributes)
            {
                var attrib = attribute as CodeAttributeDeclaration;
                if (attrib == null)
                {
                    continue;
                }

                if (attrib.Name == "System.ComponentModel.DesignerCategoryAttribute")
                {
                    
                    codeAttributes.Add(attrib);
                }
            }

            foreach (var item in codeAttributes)
            {
                customAttributes.Remove(item);
            }
        }
    }
}
