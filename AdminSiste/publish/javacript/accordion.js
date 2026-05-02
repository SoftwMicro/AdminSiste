// accordion.js
// Lógica do accordion de soluções conforme rf03.md

(function() {
  function closeAllExcept(current) {
    document.querySelectorAll('.accordion-item').forEach(item => {
      if (item !== current) {
        item.classList.remove('aberto');
        const content = item.querySelector('.accordion-content');
        content.style.maxHeight = null;
        item.querySelector('.accordion-icon').textContent = '+';
      }
    });
  }

  document.addEventListener('click', function(e) {
    if (e.target.classList.contains('accordion-header')) {
      const item = e.target.parentElement;
      const content = item.querySelector('.accordion-content');
      const icon = e.target.querySelector('.accordion-icon');
      const isOpen = item.classList.contains('aberto');
      if (!isOpen) {
        closeAllExcept(item);
        item.classList.add('aberto');
        content.style.maxHeight = content.scrollHeight + 'px';
        icon.textContent = '-';
      } else {
        item.classList.remove('aberto');
        content.style.maxHeight = null;
        icon.textContent = '+';
      }
    }
  });

  // Inicializa todos fechados
  document.addEventListener('DOMContentLoaded', function() {
    document.querySelectorAll('.accordion-content').forEach(content => {
      content.style.maxHeight = null;
    });
  });
})();
