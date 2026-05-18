using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AdminSiste.Models.Servico;
using AdminSiste.Services.Servico;

namespace AdminSiste.Pages.Servico
{
    public class ServicoCadastroModel : PageModel
    {
        private readonly ServicoService _servicoService;
        public ServicoCadastroModel(ServicoService servicoService)
        {
            _servicoService = servicoService;
        }

        [BindProperty]
        public ServicoViewModel Servico { get; set; } = new ServicoViewModel();
        [BindProperty]
        public IFormFile? ArquivoUpload { get; set; }

        public void OnGet(int? id = null)
        {
            if (id.HasValue)
            {
                var servicoEntity = _servicoService.ObterPorIdAsync(id.Value).Result;
                if (servicoEntity != null)
                {
                    Servico = new ServicoViewModel
                    {
                        Id = servicoEntity.Id,
                        Nome = servicoEntity.Nome ?? string.Empty,
                        CodigoInterno = servicoEntity.CodigoInterno ?? string.Empty,
                        ValorCusto = servicoEntity.ValorCusto,
                        ValorVenda = servicoEntity.ValorVenda,
                        Comissao = servicoEntity.Comissao,
                        Descricao = servicoEntity.Descricao ?? string.Empty,
                        AtividadeServico = servicoEntity.Atividade?.AtividadeServico ?? string.Empty,
                        CodigoServico = servicoEntity.Atividade?.CodigoServico ?? string.Empty,
                        CodigoTributacao = servicoEntity.Atividade?.CodigoTributacao ?? string.Empty,
                        CodigoNBS = servicoEntity.Atividade?.CodigoNBS ?? string.Empty,
                        CNAE = servicoEntity.Atividade?.CNAE ?? string.Empty,
                        DescricaoAtividade = servicoEntity.Atividade?.DescricaoAtividade ?? string.Empty,
                        PercentualISS = servicoEntity.Impostos?.PercentualISS ?? 0,
                        PercentualCOFINS = servicoEntity.Impostos?.PercentualCOFINS ?? 0,
                        PercentualPIS = servicoEntity.Impostos?.PercentualPIS ?? 0,
                        PercentualCSLL = servicoEntity.Impostos?.PercentualCSLL ?? 0,
                        PercentualIR = servicoEntity.Impostos?.PercentualIR ?? 0,
                        PercentualINSS = servicoEntity.Impostos?.PercentualINSS ?? 0,
                        DescontarImpostos = servicoEntity.DescontarImpostos,
                        ConstrucaoCivil = servicoEntity.ConstrucaoCivil,
                        DescontarDeducoes = servicoEntity.DescontarDeducoes,
                        BeneficioMunicipal = servicoEntity.BeneficioMunicipal,
                        ArquivoUpload = servicoEntity.ArquivoUpload ?? string.Empty
                    };
                }
            }

            if (Servico == null)
            {
                Servico = new ServicoViewModel
                {
                    CodigoInterno = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString()
                };
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            // Salvar arquivo se enviado
            string? arquivoPath = null;
            if (ArquivoUpload != null)
            {
                var uploads = Path.Combine("wwwroot", "uploads");
                Directory.CreateDirectory(uploads);
                arquivoPath = Path.Combine(uploads, ArquivoUpload.FileName);
                using (var stream = new FileStream(arquivoPath, FileMode.Create))
                {
                    await ArquivoUpload.CopyToAsync(stream);
                }
            }

            // Mapear ViewModel para Entidades
            var servico = new Models.Servico.Servico
            {
                Id = Servico.Id,
                Nome = Servico.Nome,
                CodigoInterno = Servico.CodigoInterno,
                ValorCusto = Servico.ValorCusto,
                ValorVenda = Servico.ValorVenda,
                Comissao = Servico.Comissao,
                Descricao = Servico.Descricao,
                Atividade = new ServicoAtividade
                {
                    AtividadeServico = Servico.AtividadeServico,
                    CodigoServico = Servico.CodigoServico,
                    CodigoTributacao = Servico.CodigoTributacao,
                    CodigoNBS = Servico.CodigoNBS,
                    CNAE = Servico.CNAE,
                    DescricaoAtividade = Servico.DescricaoAtividade
                },
                Impostos = new ServicoImpostos
                {
                    PercentualISS = Servico.PercentualISS,
                    PercentualCOFINS = Servico.PercentualCOFINS,
                    PercentualPIS = Servico.PercentualPIS,
                    PercentualCSLL = Servico.PercentualCSLL,
                    PercentualIR = Servico.PercentualIR,
                    PercentualINSS = Servico.PercentualINSS
                },
                DescontarImpostos = Servico.DescontarImpostos,
                ConstrucaoCivil = Servico.ConstrucaoCivil,
                DescontarDeducoes = Servico.DescontarDeducoes,
                BeneficioMunicipal = Servico.BeneficioMunicipal,
                ArquivoUpload = arquivoPath
            };

            await _servicoService.AdicionarAsync(servico);
            return RedirectToPage("/Servico/ServicoLista");
        }
    }
}
