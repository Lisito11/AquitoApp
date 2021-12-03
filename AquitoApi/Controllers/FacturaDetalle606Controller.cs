
using AquitoApi.DTOs.Facturas606;
using AquitoApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using GemBox.Spreadsheet;
using System.IO;
using System;

namespace AquitoApi.Controllers
{
    [ApiController]
    [Route("api/detallefactura606")]
    public class FacturaDetalle606Controller : CustomBaseController
    {
        private readonly d2bc1ckqeusvkjContext context;
        private readonly IMapper mapper;
        public FacturaDetalle606Controller(d2bc1ckqeusvkjContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        //Metodo Get
        [HttpGet]
        public async Task<ActionResult<List<FacturaDetalle606DTO>>> Get()
        {
            var facturas = await context.FacturaDetalles606s.ToListAsync();
            return mapper.Map<List<FacturaDetalle606DTO>>(facturas);
        }

        //Metodo Get de una factura
        [HttpGet("main/{id:int}")]
        public async Task<ActionResult<List<FacturaDetalle606DTO>>> GetFacturas(int id)
        {
            var facturas = await context.FacturaDetalles606s.Where(x=> x.factura606id == id).ToListAsync();
            return mapper.Map<List<FacturaDetalle606DTO>>(facturas);
        }

        //EXPORT
        [HttpGet("main/{id:int}/export")]
        public async Task<IActionResult> Export(int id)
        {


            var book = new ExcelFile();

            var sheet = book.Worksheets.Add("Factura606");
            
            var facturas = await context.FacturaDetalles606s.Where(x => x.factura606id == id).ToListAsync();

            //Estilos al excel
            CellStyle style = sheet.Rows[0].Style;
            style.Font.Weight = ExcelFont.BoldWeight;
            style.HorizontalAlignment = HorizontalAlignmentStyle.Center;
            sheet.Columns[0].Style.HorizontalAlignment = HorizontalAlignmentStyle.Center;

            //Colocando las columnas
            sheet.Columns[0].SetWidth(150, LengthUnit.Pixel);
            sheet.Columns[1].SetWidth(150, LengthUnit.Pixel);
            sheet.Columns[2].SetWidth(150, LengthUnit.Pixel);
            sheet.Columns[3].SetWidth(150, LengthUnit.Pixel);
            sheet.Columns[5].SetWidth(150, LengthUnit.Pixel);
            sheet.Columns[6].SetWidth(300, LengthUnit.Pixel);

            sheet.Cells["A1"].Value = "Tipo Bienes y Servicios Comprados";
            sheet.Cells["B1"].Value = "NCF";
            sheet.Cells["C1"].Value = "Fecha Comprobante Fiscal";
            sheet.Cells["D1"].Value = "Forma Pago";
            sheet.Cells["E1"].Value = "ITBIS Facturado";
            sheet.Cells["F1"].Value = "Monto Facturado";

            //Llenando las filas
            for (int r = 1; r <= facturas.Count; r++)
            {
                FacturaDetalle606 item = facturas[r - 1];
                sheet.Cells[r, 0].Value = item.TypeVenta;
                sheet.Cells[r, 1].Value = item.Comprobante;
                sheet.Cells[r, 2].Value = item.ComprobanteDate.Value.ToString("yyyy-MM-dd");
                sheet.Cells[r, 3].Value = item.FormaPago;
                sheet.Cells[r, 4].Value = item.Itbis;
                sheet.Cells[r, 5].Value = item.Monto;
            }

            SaveOptions options = GetSaveOptions("XLSX");

            using (var stream = new MemoryStream())
            {
                book.Save(stream, options);
                return File(stream.ToArray(), options.ContentType, "factura606." + "XLSX");
            }

        }

        private static SaveOptions GetSaveOptions(string format)
        {
            switch (format.ToUpper())
            {
                case "XLSX":
                    return SaveOptions.XlsxDefault;
                case "XLS":
                    return SaveOptions.XlsDefault;
                case "ODS":
                    return SaveOptions.OdsDefault;
                case "CSV":
                    return SaveOptions.CsvDefault;
                case "HTML":
                    return SaveOptions.HtmlDefault;
                case "PDF":
                    return SaveOptions.PdfDefault;
                case "XPS":
                case "PNG":
                case "JPG":
                case "GIF":
                case "TIF":
                case "BMP":
                case "WMP":
                    throw new InvalidOperationException("To enable saving to XPS or image format, add 'Microsoft.WindowsDesktop.App' framework reference.");
                default:
                    throw new NotSupportedException();
            }
        }

        [HttpGet("{id:int}", Name = "obtenerFacturaDetalle606")]
        public async Task<ActionResult<FacturaDetalle606DTO>> Get(int id)
        {
            FacturaDetalle606 factura = await context.FacturaDetalles606s.FirstOrDefaultAsync(x => x.Id == id);
            return mapper.Map<FacturaDetalle606DTO>(factura);
        }

        //Metodo Post
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FacturaDetalle606CreacionDTO facturaDetalle606CreacionDTO)
        {
            return await Post<FacturaDetalle606CreacionDTO, FacturaDetalle606, FacturaDetalle606DTO>(facturaDetalle606CreacionDTO, "obtenerFacturaDetalle606");
        }

        //Metodo Put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] FacturaDetalle606CreacionDTO facturaDetalle606CreacionDTO)
        {
            return await Put<FacturaDetalle606CreacionDTO, FacturaDetalle606>(id, facturaDetalle606CreacionDTO);
        }

        //Metodo Patch
        [HttpPatch("{id:int}")]
        public async Task<ActionResult> Patch(int id, JsonPatchDocument<FacturaDetalle606> patchDoc)
        {
            return await Patch<FacturaDetalle606, FacturaDetalle606DTO>(id, patchDoc);
        }
    }
}
