using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AdminSiste.Models.Servico;
using AdminSiste.Services.Servico;
using System.IO;


namespace AdminSiste.Controllers
{
    [Route("servico")]
    [Authorize]
    public class ServicoController : Controller
    {
        private readonly ServicoService _servicoService;
        public ServicoController(ServicoService servicoService)
        {
            _servicoService = servicoService;
        }

            // Endpoint de teste para verificar se o controller está ativo
            [HttpGet("ping")]
            public IActionResult Ping()
            {
                Console.WriteLine("Ping chamado");
                return Ok("ServicoController ativo");
            }

        [HttpGet("DownloadArquivo/{id}")]
        public async Task<IActionResult> DownloadArquivo(int id)
        {
            var servico = await _servicoService.ObterPorIdAsync(id);
            if (servico == null || string.IsNullOrEmpty(servico.ArquivoUpload))
                return NotFound();


            var filePath = servico.ArquivoUpload;
            // Se não for caminho absoluto, buscar em wwwroot/uploads
            if (!Path.IsPathRooted(filePath))
            {
                // Se já começa com wwwroot ou uploads, não adicionar novamente
                if (filePath.StartsWith("wwwroot" + Path.DirectorySeparatorChar) || filePath.StartsWith("uploads" + Path.DirectorySeparatorChar))
                {
                    filePath = Path.Combine(Directory.GetCurrentDirectory(), filePath);
                }
                else
                {
                    filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", filePath);
                }
            }
            if (!System.IO.File.Exists(filePath))
                return NotFound();

            var fileName = Path.GetFileName(filePath);
            var contentType = "application/octet-stream";
            return PhysicalFile(filePath, contentType, fileName);
        }
    }
}
