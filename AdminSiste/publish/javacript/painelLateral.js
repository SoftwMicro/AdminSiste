// painelLateral.js
// Cria e gerencia o painel lateral dinâmico conforme rf02.md



// Painel Lateral Dinâmico para Produtos & Serviços e Outsourcing
(function() {
  let painelSolucoes = null;
  let painelOutsourcing = null;

  // Painel de Soluções (Produtos & Serviços)
  function criarPainelSolucoes() {
    painelSolucoes = document.createElement('div');
    painelSolucoes.id = 'painel-lateral';
    painelSolucoes.innerHTML = `
      <button id="fechar-painel" aria-label="Fechar painel">&times;</button>
      <h2>Soluções</h2>
      <div class="accordion">
        <div class="accordion-item">
          <div class="accordion-header"><span class="accordion-icon">+</span> Gerenciamento de Projetos</div>
          <div class="accordion-content">
          <div class="gerenciamento-projetos">
          <h3>Gerenciamento de Projetos com Rigor Estratégico</h3>
          <p>
              Baseamos nossa metodologia no <strong>PMBOK®</strong>, garantindo previsibilidade, 
              controle de custos e qualidade em cada entrega. Atuamos em frentes críticas 
              para o crescimento organizacional:
          </p>
          <ul>
              <li>
                  <strong>Inovação:</strong> Desenvolvimento completo de novos produtos e serviços.
              </li>
              <li>
                  <strong>Transformação:</strong> Gestão de mudanças estruturais e modernização de infraestrutura.
              </li>
              <li>
                  <strong>Sistemas:</strong> Inteligência na aquisição e implementação de sistemas de informação.
              </li>
              <li>
                  <strong>Processos:</strong> Reestruturação de procedimentos de negócios para máxima eficiência.
              </li>
          </ul>
      </div> 
          </div>
        </div>
        <div class="accordion-item">
          <div class="accordion-header"><span class="accordion-icon">+</span> Sistemas de Informações</div>
          <div class="accordion-content">
             <div class="sistemas-informacao">
             <h3>Ecossistema de Sistemas de Informação</h3>
                  <p>
                      Oferecemos suporte tecnológico de ponta a ponta. Do código à rede, cuidamos da 
                      infraestrutura para que você foque no que realmente importa: <strong>seu cliente</strong>.
                  </p>
                  <ul>
                      <li>
                          <strong>Desenvolvimento sob Medida:</strong> Aplicativos móveis e sistemas web robustos.
                      </li>
                      <li>
                          <strong>Infraestrutura e Dados:</strong> Gestão de bancos de dados, servidores, hospedagem e redes de computadores.
                      </li>
                      <li>
                          <strong>Presença Digital:</strong> Estratégias de Marketing Digital para escalar sua visibilidade.
                      </li>
                  </ul>
          </div>
          </div>
        </div>
        <div class="accordion-item">
          <div class="accordion-header"><span class="accordion-icon">+</span> Desenvolvimento de Sistemas</div>
          <div class="accordion-content">
             <div class="especialistas-negocios">
      <h3>Especialistas em Micro e Pequenos Negócios</h3>
      <p>
          Entendemos os desafios únicos de empresas em crescimento. Desenvolvemos sistemas personalizados 
          adaptando a tecnologia à realidade de cada mercado, com foco em <strong>resultados e escalabilidade</strong>.
      </p>
      <h4>Principais Segmentos de Atuação no Brasil</h4>
      <ul>
          <li><strong>Comércio e Varejo:</strong> Automação de vendas e PDV.</li>
          <li><strong>Distribuição e Logística:</strong> Controle de estoque e rotas.</li>
          <li><strong>Vestuário e Moda:</strong> Gestão de produção e e-commerce.</li>
          <li><strong>Serviços:</strong> Sistemas de agendamento e gestão de clientes (CRM).</li>
          <li><strong>Educação:</strong> Plataformas de ensino e portais acadêmicos.</li>
          <li><strong>Saúde e Bem-estar:</strong> Gestão de clínicas e prontuários.</li>
          <li><strong>Gastronomia:</strong> Sistemas para restaurantes e delivery.</li>
          <li><strong>Agronegócio:</strong> Monitoramento e gestão rural.</li>
          <li><strong>Imobiliário:</strong> Portfólio digital e gestão de contratos.</li>
          <li><strong>Petshops:</strong> Controle de serviços e histórico animal.</li>
      </ul>
      <h4>Tecnologias e Frameworks de Alta Performance</h4>
      <p>Utilizamos o que há de mais moderno para garantir segurança e velocidade:</p>
      <ul>
          <li><strong>Backend:</strong> C# (.NET), Node.js e Python.</li>
          <li><strong>Frontend:</strong> React e Angular.</li>
          <li><strong>Mobile:</strong> .NET MAUI e React Native (Android/iOS).</li>
          <li><strong>Banco de Dados:</strong> SQL Server, PostgreSQL e MongoDB.</li>
          <li><strong>Infraestrutura:</strong> Docker e Azure/AWS.</li>
      </ul>
  </div>
          </div>
        </div>
        <div class="accordion-item">
          <div class="accordion-header"><span class="accordion-icon">+</span> Consultoria</div>
          <div class="accordion-content">
            <div class="consultoria-capacitacao">
      <h3>Consultoria e Capacitação Técnica</h3>
      <p>
          Mais do que entregar software, entregamos conhecimento. Nossa consultoria abrange 
          pontos estratégicos para garantir que sua empresa opere com a 
          <strong>máxima eficiência tecnológica</strong>:
      </p>
      <ul>
          <li>
              <strong>Negócios e Hardware:</strong> Apoio especializado na tomada de decisão e na escolha assertiva de ativos tecnológicos.
          </li>
          <li>
              <strong>Educação:</strong> Treinamentos personalizados e programas de certificação para qualificar e atualizar sua equipe.
          </li>
      </ul>
  </div>
          </div>
        </div>
      </div>
    `;
    painelSolucoes.style.display = 'none';
    document.body.appendChild(painelSolucoes);
    painelSolucoes.addEventListener('click', function(e) {
      if (e.target.id === 'fechar-painel') fecharPainelSolucoes();
    });
  }

  function abrirPainelSolucoes() {
    if (!painelSolucoes) criarPainelSolucoes();
    painelSolucoes.style.display = 'block';
    setTimeout(() => {
      painelSolucoes.classList.add('aberto');
    }, 10);
  }
  function fecharPainelSolucoes() {
    if (!painelSolucoes) return;
    painelSolucoes.classList.remove('aberto');
    setTimeout(() => {
      painelSolucoes.style.display = 'none';
    }, 500);
  }

  // Painel de Outsourcing (imagem centralizada, fade-in/fade-out)
  function criarPainelOutsourcing() {
    painelOutsourcing = document.createElement('div');
    painelOutsourcing.id = 'painel-outsourcing-fade';
    painelOutsourcing.innerHTML = `
      <button id="fechar-outsourcing-fade" aria-label="Fechar imagem">&times;</button>
      <img src="img/FabricAutonomousDevFactory.png" alt="Fabric Autonomous Dev Factory" class="img-outsourcing-fade" />
    `;
    painelOutsourcing.style.display = 'none';
    painelOutsourcing.style.opacity = '0';
    document.body.appendChild(painelOutsourcing);
    painelOutsourcing.querySelector('#fechar-outsourcing-fade').addEventListener('click', fecharPainelOutsourcing);
  }
  function abrirPainelOutsourcing() {
    if (!painelOutsourcing) criarPainelOutsourcing();
    painelOutsourcing.style.display = 'flex';
    setTimeout(() => {
      painelOutsourcing.style.opacity = '1';
    }, 10);
  }
  function fecharPainelOutsourcing() {
    if (!painelOutsourcing) return;
    painelOutsourcing.style.opacity = '0';
    setTimeout(() => {
      painelOutsourcing.style.display = 'none';
    }, 1200); // tempo igual ao CSS
  }

  document.addEventListener('DOMContentLoaded', function() {
    const btnProdutos = document.getElementById('produtos');
    if (btnProdutos) {
      btnProdutos.addEventListener('click', abrirPainelSolucoes);
    }
    const btnOutsourcing = document.getElementById('outsourcing');
    if (btnOutsourcing) {
      btnOutsourcing.onclick = null;
      btnOutsourcing.addEventListener('click', abrirPainelOutsourcing);
    }
  });
})();
