/**
 * Script de Limpeza e Proteção contra anúncios Somee.com
 */
const cleanupSomeeAds = () => {
  const targetText = "Hosted Windows Virtual Server. 2.5GHz CPU, 2GB RAM, 60GB SSD. Try it now for $1!";

  // 1. Função principal de remoção
  const removeAds = () => {
    // Remove elementos <center> do Somee
    document.querySelectorAll('center').forEach(el => {
      if (el.innerText.includes('Web hosting by Somee.com')) {
        el.remove();
      }
    });

    // Remove links/divs com o texto de Virtual Server
    document.querySelectorAll('a, div, span, p').forEach(el => {
      if (el.innerText && el.innerText.includes(targetText)) {
        // Remove o elemento ou o container pai se necessário
        el.closest('div') ? el.closest('div').remove() : el.remove();
      }
    });

    // Remove scripts injetados que geralmente ficam no final do body
    document.querySelectorAll('script[src*="somee.com"]').forEach(script => script.remove());
  };

  // 2. Execução imediata
  removeAds();

  // 3. Observador para evitar que o anúncio volte (Prevenção)
  const observer = new MutationObserver((mutations) => {
    removeAds();
  });

  observer.observe(document.body, {
    childList: true,
    subtree: true
  });

  console.log("✅ Limpeza concluída e monitoramento ativo.");
};

// Executar a função após o carregamento completo da página
window.onload = cleanupSomeeAds;