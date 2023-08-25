using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace form_409_check.VTB_XML
{
    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:schemas-microsoft-com:office:spreadsheet")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:schemas-microsoft-com:office:spreadsheet", IsNullable = false)]
    public partial class Workbook
    {

        private DocumentProperties? documentPropertiesField;

        private WorkbookStyle[]? stylesField;

        private WorkbookWorksheet? worksheetField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:schemas-microsoft-com:office:office")]
        public DocumentProperties DocumentProperties
        {
            get
            {
                return this.documentPropertiesField;
            }
            set
            {
                this.documentPropertiesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Style", IsNullable = false)]
        public WorkbookStyle[] Styles
        {
            get
            {
                return this.stylesField;
            }
            set
            {
                this.stylesField = value;
            }
        }

        /// <remarks/>
        public WorkbookWorksheet Worksheet
        {
            get
            {
                return this.worksheetField;
            }
            set
            {
                this.worksheetField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:schemas-microsoft-com:office:office")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:schemas-microsoft-com:office:office", IsNullable = false)]
    public partial class DocumentProperties
    {

        private string? authorField;

        private string? lastAuthorField;

        private object? createdField;

        private byte versionField;

        /// <remarks/>
        public string Author
        {
            get
            {
                return this.authorField;
            }
            set
            {
                this.authorField = value;
            }
        }

        /// <remarks/>
        public string LastAuthor
        {
            get
            {
                return this.lastAuthorField;
            }
            set
            {
                this.lastAuthorField = value;
            }
        }

        /// <remarks/>
        public object Created
        {
            get
            {
                return this.createdField;
            }
            set
            {
                this.createdField = value;
            }
        }

        /// <remarks/>
        public byte Version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:schemas-microsoft-com:office:spreadsheet")]
    public partial class WorkbookStyle
    {

        private WorkbookStyleAlignment? alignmentField;

        private WorkbookStyleBorder[]? bordersField;

        private WorkbookStyleFont? fontField;

        private byte idField;

        /// <remarks/>
        public WorkbookStyleAlignment Alignment
        {
            get
            {
                return this.alignmentField;
            }
            set
            {
                this.alignmentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Border", IsNullable = false)]
        public WorkbookStyleBorder[] Borders
        {
            get
            {
                return this.bordersField;
            }
            set
            {
                this.bordersField = value;
            }
        }

        /// <remarks/>
        public WorkbookStyleFont Font
        {
            get
            {
                return this.fontField;
            }
            set
            {
                this.fontField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public byte ID
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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:schemas-microsoft-com:office:spreadsheet")]
    public partial class WorkbookStyleAlignment
    {

        private string? verticalField;

        private string? horizontalField;

        private byte wrapTextField;

        private bool wrapTextFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Vertical
        {
            get
            {
                return this.verticalField;
            }
            set
            {
                this.verticalField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Horizontal
        {
            get
            {
                return this.horizontalField;
            }
            set
            {
                this.horizontalField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public byte WrapText
        {
            get
            {
                return this.wrapTextField;
            }
            set
            {
                this.wrapTextField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WrapTextSpecified
        {
            get
            {
                return this.wrapTextFieldSpecified;
            }
            set
            {
                this.wrapTextFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:schemas-microsoft-com:office:spreadsheet")]
    public partial class WorkbookStyleBorder
    {

        private string? positionField;

        private string? lineStyleField;

        private byte weightField;

        private string? colorField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Position
        {
            get
            {
                return this.positionField;
            }
            set
            {
                this.positionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string LineStyle
        {
            get
            {
                return this.lineStyleField;
            }
            set
            {
                this.lineStyleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public byte Weight
        {
            get
            {
                return this.weightField;
            }
            set
            {
                this.weightField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Color
        {
            get
            {
                return this.colorField;
            }
            set
            {
                this.colorField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:schemas-microsoft-com:office:spreadsheet")]
    public partial class WorkbookStyleFont
    {

        private string? fontNameField;

        private byte sizeField;

        private string? colorField;

        private byte boldField;

        private bool boldFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string FontName
        {
            get
            {
                return this.fontNameField;
            }
            set
            {
                this.fontNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public byte Size
        {
            get
            {
                return this.sizeField;
            }
            set
            {
                this.sizeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string Color
        {
            get
            {
                return this.colorField;
            }
            set
            {
                this.colorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public byte Bold
        {
            get
            {
                return this.boldField;
            }
            set
            {
                this.boldField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BoldSpecified
        {
            get
            {
                return this.boldFieldSpecified;
            }
            set
            {
                this.boldFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:schemas-microsoft-com:office:spreadsheet")]
    public partial class WorkbookWorksheet
    {

        private WorkbookWorksheetTable? tableField;

        private string? nameField;

        /// <remarks/>
        public WorkbookWorksheetTable Table
        {
            get
            {
                return this.tableField;
            }
            set
            {
                this.tableField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:schemas-microsoft-com:office:spreadsheet")]
    public partial class WorkbookWorksheetTable
    {

        private WorkbookWorksheetTableColumn[]? columnField;

        private WorkbookWorksheetTableRow[]? rowField;

        private byte expandedColumnCountField;

        private int expandedRowCountField;

        private byte fullColumnsField;

        private byte fullRowsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Column")]
        public WorkbookWorksheetTableColumn[] Column
        {
            get
            {
                return this.columnField;
            }
            set
            {
                this.columnField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Row")]
        public WorkbookWorksheetTableRow[] Row
        {
            get
            {
                return this.rowField;
            }
            set
            {
                this.rowField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public byte ExpandedColumnCount
        {
            get
            {
                return this.expandedColumnCountField;
            }
            set
            {
                this.expandedColumnCountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public int ExpandedRowCount
        {
            get
            {
                return this.expandedRowCountField;
            }
            set
            {
                this.expandedRowCountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "urn:schemas-microsoft-com:office:excel")]
        public byte FullColumns
        {
            get
            {
                return this.fullColumnsField;
            }
            set
            {
                this.fullColumnsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "urn:schemas-microsoft-com:office:excel")]
        public byte FullRows
        {
            get
            {
                return this.fullRowsField;
            }
            set
            {
                this.fullRowsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:schemas-microsoft-com:office:spreadsheet")]
    public partial class WorkbookWorksheetTableColumn
    {

        private byte autoFitWidthField;

        private decimal widthField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public byte AutoFitWidth
        {
            get
            {
                return this.autoFitWidthField;
            }
            set
            {
                this.autoFitWidthField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public decimal Width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:schemas-microsoft-com:office:spreadsheet")]
    public partial class WorkbookWorksheetTableRow
    {

        private WorkbookWorksheetTableRowCell[]? cellField;

        private byte autoFitHeightField;

        private bool autoFitHeightFieldSpecified;

        private byte heightField;

        private bool heightFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Cell")]
        public WorkbookWorksheetTableRowCell[] Cell
        {
            get
            {
                return this.cellField;
            }
            set
            {
                this.cellField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public byte AutoFitHeight
        {
            get
            {
                return this.autoFitHeightField;
            }
            set
            {
                this.autoFitHeightField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AutoFitHeightSpecified
        {
            get
            {
                return this.autoFitHeightFieldSpecified;
            }
            set
            {
                this.autoFitHeightFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public byte Height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool HeightSpecified
        {
            get
            {
                return this.heightFieldSpecified;
            }
            set
            {
                this.heightFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:schemas-microsoft-com:office:spreadsheet")]
    public partial class WorkbookWorksheetTableRowCell
    {

        private WorkbookWorksheetTableRowCellData? dataField;

        private byte styleIDField;

        /// <remarks/>
        public WorkbookWorksheetTableRowCellData Data
        {
            get
            {
                return this.dataField;
            }
            set
            {
                this.dataField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public byte StyleID
        {
            get
            {
                return this.styleIDField;
            }
            set
            {
                this.styleIDField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:schemas-microsoft-com:office:spreadsheet")]
    public partial class WorkbookWorksheetTableRowCellData
    {

        private string? typeField;

        private string? valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
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
