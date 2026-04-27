// Alternância entre Login e Cadastro
function toggleAuth(view) {
  const loginForm = document.getElementById('login-form');
  const cadastroForm = document.getElementById('cadastro-form');
  if (view === 'cadastro') {
    loginForm.style.display = 'none';
    cadastroForm.style.display = 'block';
  } else {
    loginForm.style.display = 'block';
    cadastroForm.style.display = 'none';
  }
}
