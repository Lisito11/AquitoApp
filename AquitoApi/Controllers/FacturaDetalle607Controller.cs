
using AquitoApi.DTOs.Facturas607;
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
    [Route("api/detallefactura607")]
    public class FacturaDetalle607Controller: CustomBaseController
    {
        private readonly d2bc1ckqeusvkjContext context;
        private readonly IMapper mapper;
        public FacturaDetalle607Controller(d2bc1ckqeusvkjContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        //Metodo Get
        [HttpGet]
        public async Task<ActionResult<List<FacturaDetalle607DTO>>> Get()
        {
            var facturas = await context.FacturaDetalles607s.ToListAsync();
            return mapper.Map<List<FacturaDetalle607DTO>>(facturas);
        }

        //Metodo Get de una factura
        [HttpGet("main/{id:int}")]
        public async Task<ActionResult<List<FacturaDetalle607DTO>>> GetFacturas(int id)
        {
            var facturas = await context.FacturaDetalles607s.Where(x => x.factura607id == id).ToListAsync();
            return mapper.Map<List<FacturaDetalle607DTO>>(facturas);
        }

        [HttpGet("{id:int}", Name = "obtenerFacturaDetalle607")]
        public async Task<ActionResult<FacturaDetalle607DTO>> Get(int id)
        {
            FacturaDetalle607 factura = await context.FacturaDetalles607s.FirstOrDefaultAsync(x => x.Id == id);
            return mapper.Map<FacturaDetalle607DTO>(factura);
        }
        //EXPORT
        [HttpGet("main/{id:int}/export")]
        public async Task<IActionResult> Export(int id)
        {


            var book = new ExcelFile();

            var sheet = book.Worksheets.Add("Factura607");

            var facturas = await context.FacturaDetalles607s.Where(x => x.factura607id == id).ToListAsync();

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

            sheet.Cells["A1"].Value = "NCF";
            sheet.Cells["B1"].Value = "Fecha Comprobante Fiscal";
            sheet.Cells["C1"].Value = "Tipo de Ingreso";
            sheet.Cells["D1"].Value = "ITBIS Facturado";
            sheet.Cells["E1"].Value = "Monto Facturado";

            //Llenando las filas
            for (int r = 1; r <= facturas.Count; r++)
            {
                FacturaDetalle607 item = facturas[r - 1];
                sheet.Cells[r, 0].Value = item.Comprobante;
                sheet.Cells[r, 1].Value = item.ComprobanteDate.Value.ToString("yyyy-MM-dd");
                sheet.Cells[r, 2].Value = item.TypeIncome;
                sheet.Cells[r, 3].Value = item.Itbis;
                sheet.Cells[r, 4].Value = item.Monto;
            }

            SaveOptions options = GetSaveOptions("XLSX");

            using (var stream = new MemoryStream())
            {
                book.Save(stream, options);
                return File(stream.ToArray(), options.ContentType, "factura607." + "XLSX");
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
        //Metodo Post
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FacturaDetalle607CreacionDTO facturaDetalle607CreacionDTO)
        {
            return await Post<FacturaDetalle607CreacionDTO, FacturaDetalle607, FacturaDetalle607DTO>(facturaDetalle607CreacionDTO, "obtenerFacturaDetalle607");
        }

        //Metodo Put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] FacturaDetalle607CreacionDTO facturaDetalle607CreacionDTO)
        {
            return await Put<FacturaDetalle607CreacionDTO, FacturaDetalle607>(id, facturaDetalle607CreacionDTO);
        }

        //Metodo Patch
        [HttpPatch("{id:int}")]
        public async Task<ActionResult> Patch(int id, JsonPatchDocument<FacturaDetalle607> patchDoc)
        {
            return await Patch<FacturaDetalle607, FacturaDetalle607DTO>(id, patchDoc);
        }
    }
}
