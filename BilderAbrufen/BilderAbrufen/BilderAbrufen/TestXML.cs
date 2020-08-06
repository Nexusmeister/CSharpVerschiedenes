using System;
using System.Collections.Generic;
using System.Text;

namespace BilderAbrufen
{
    public class TestXML
    {

        // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class Product
        {

            private string nameField;

            private ProductClassificationReference[] classificationReferenceField;

            private ProductAssetCrossReference[] assetCrossReferenceField;

            private ProductEntityCrossReference[] entityCrossReferenceField;

            private ProductValues valuesField;

            private string parentIDField;

            private string idField;

            private string titleField;

            private string userTypeIdField;

            private string contextField;

            private string workspaceField;

            /// <remarks/>
            public string Name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("ClassificationReference")]
            public ProductClassificationReference[] ClassificationReference
            {
                get
                {
                    return this.classificationReferenceField;
                }
                set
                {
                    this.classificationReferenceField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("AssetCrossReference")]
            public ProductAssetCrossReference[] AssetCrossReference
            {
                get
                {
                    return this.assetCrossReferenceField;
                }
                set
                {
                    this.assetCrossReferenceField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("EntityCrossReference")]
            public ProductEntityCrossReference[] EntityCrossReference
            {
                get
                {
                    return this.entityCrossReferenceField;
                }
                set
                {
                    this.entityCrossReferenceField = value;
                }
            }

            /// <remarks/>
            public ProductValues Values
            {
                get
                {
                    return this.valuesField;
                }
                set
                {
                    this.valuesField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string ParentID
            {
                get
                {
                    return this.parentIDField;
                }
                set
                {
                    this.parentIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string ID
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string title
            {
                get
                {
                    return this.titleField;
                }
                set
                {
                    this.titleField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string UserTypeId
            {
                get
                {
                    return this.userTypeIdField;
                }
                set
                {
                    this.userTypeIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Context
            {
                get
                {
                    return this.contextField;
                }
                set
                {
                    this.contextField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Workspace
            {
                get
                {
                    return this.workspaceField;
                }
                set
                {
                    this.workspaceField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class ProductClassificationReference
        {

            private object valuesField;

            private string classificationIDField;

            private string titleField;

            private string typeField;

            /// <remarks/>
            public object Values
            {
                get
                {
                    return this.valuesField;
                }
                set
                {
                    this.valuesField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string ClassificationID
            {
                get
                {
                    return this.classificationIDField;
                }
                set
                {
                    this.classificationIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string title
            {
                get
                {
                    return this.titleField;
                }
                set
                {
                    this.titleField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Type
            {
                get
                {
                    return this.typeField;
                }
                set
                {
                    this.typeField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class ProductAssetCrossReference
        {

            private ProductAssetCrossReferenceValues valuesField;

            private uint assetIDField;

            private uint titleField;

            private string typeField;

            /// <remarks/>
            public ProductAssetCrossReferenceValues Values
            {
                get
                {
                    return this.valuesField;
                }
                set
                {
                    this.valuesField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public uint AssetID
            {
                get
                {
                    return this.assetIDField;
                }
                set
                {
                    this.assetIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public uint title
            {
                get
                {
                    return this.titleField;
                }
                set
                {
                    this.titleField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Type
            {
                get
                {
                    return this.typeField;
                }
                set
                {
                    this.typeField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class ProductAssetCrossReferenceValues
        {

            private ProductAssetCrossReferenceValuesValue valueField;

            /// <remarks/>
            public ProductAssetCrossReferenceValuesValue Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class ProductAssetCrossReferenceValuesValue
        {

            private string attributeIDField;

            private string titleField;

            private string valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string AttributeID
            {
                get
                {
                    return this.attributeIDField;
                }
                set
                {
                    this.attributeIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string title
            {
                get
                {
                    return this.titleField;
                }
                set
                {
                    this.titleField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public string Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class ProductEntityCrossReference
        {

            private object valuesField;

            private string entityIDField;

            private string titleField;

            private string typeField;

            /// <remarks/>
            public object Values
            {
                get
                {
                    return this.valuesField;
                }
                set
                {
                    this.valuesField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string EntityID
            {
                get
                {
                    return this.entityIDField;
                }
                set
                {
                    this.entityIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string title
            {
                get
                {
                    return this.titleField;
                }
                set
                {
                    this.titleField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Type
            {
                get
                {
                    return this.typeField;
                }
                set
                {
                    this.typeField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class ProductValues
        {

            private ProductValuesValue[] valueField;

            private ProductValuesMultiValue[] multiValueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("Value")]
            public ProductValuesValue[] Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("MultiValue")]
            public ProductValuesMultiValue[] MultiValue
            {
                get
                {
                    return this.multiValueField;
                }
                set
                {
                    this.multiValueField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class ProductValuesValue
        {

            private string attributeIDField;

            private string externalIDField;

            private string titleField;

            private string valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string AttributeID
            {
                get
                {
                    return this.attributeIDField;
                }
                set
                {
                    this.attributeIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string ExternalID
            {
                get
                {
                    return this.externalIDField;
                }
                set
                {
                    this.externalIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string title
            {
                get
                {
                    return this.titleField;
                }
                set
                {
                    this.titleField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public string Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class ProductValuesMultiValue
        {

            private ProductValuesMultiValueValue[] valueField;

            private string attributeIDField;

            private string titleField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("Value")]
            public ProductValuesMultiValueValue[] Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string AttributeID
            {
                get
                {
                    return this.attributeIDField;
                }
                set
                {
                    this.attributeIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string title
            {
                get
                {
                    return this.titleField;
                }
                set
                {
                    this.titleField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class ProductValuesMultiValueValue
        {

            private string externalIDField;

            private string valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string ExternalID
            {
                get
                {
                    return this.externalIDField;
                }
                set
                {
                    this.externalIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public string Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }


    }
}
