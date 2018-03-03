# excellibrary
Automatically exported from code.google.com/p/excellibrary

I do not intend to update this library unless I have to but feel free to open issues or create pull request. I would be happy to transfer ownership to someone who like to work on this. I'm not the orignal author.

The aim of this project is provide a native .NET solution to create, read and modify Excel files without using COM interop or OLEDB connection.

Currently .xls (BIFF8) format is implemented. Use other libraries for .xlsx (Excel 2007).

Example code:
```
//create new xls file string file = "C:\newdoc.xls"; 
Workbook workbook = new Workbook(); 
Worksheet worksheet = new Worksheet("First Sheet"); 
worksheet.Cells[0, 1] = new Cell((short)1); 
worksheet.Cells[2, 0] = new Cell(9999999); 
worksheet.Cells[3, 3] = new Cell((decimal)3.45);
worksheet.Cells[2, 2] = new Cell("Text string"); 
worksheet.Cells[2, 4] = new Cell("Second string"); 
worksheet.Cells[4, 0] = new Cell(32764.5, "#,##0.00");
worksheet.Cells[5, 1] = new Cell(DateTime.Now, @"YYYY-MM-DD");
worksheet.Cells.ColumnWidth[0, 1] = 3000;
workbook.Worksheets.Add(worksheet); workbook.Save(file);

// open xls file 
Workbook book = Workbook.Load(file); 
Worksheet sheet = book.Worksheets[0];

// traverse cells
foreach (Pair, Cell> cell in sheet.Cells) 
{ 
    dgvCells[cell.Left.Right, cell.Left.Left].Value = cell.Right.Value; 
}

// traverse rows by Index 
for (int rowIndex = sheet.Cells.FirstRowIndex; rowIndex <= sheet.Cells.LastRowIndex; rowIndex++) 
{
    Row row = sheet.Cells.GetRow(rowIndex); 
    for (int colIndex = row.FirstColIndex; colIndex <= row.LastColIndex; colIndex++)
    {
        Cell cell = row.GetCell(colIndex); 
    } 
} 
```
