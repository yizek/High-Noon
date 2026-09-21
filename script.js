// ---------- Navegação entre seções (SPA de página única) ----------

const pages = document.querySelectorAll('.page');
const navLinks = document.querySelectorAll('[data-nav]');

function goToPage(id) {
  pages.forEach(page => {
    page.hidden = page.id !== id;
  });

  navLinks.forEach(link => {
    link.classList.toggle('active', link.dataset.nav === id);
  });

  const mainNav = document.getElementById('mainNav');
  if (mainNav) {
    mainNav.classList.toggle('nav-hidden', id === 'home');
  }

  window.scrollTo({ top: 0, behavior: 'instant' in window ? 'instant' : 'auto' });
}

const prefersReducedMotion = window.matchMedia('(prefers-reduced-motion: reduce)').matches;
const doorOverlay = document.getElementById('doorTransition');
const DOOR_OPEN_MS = 850;
const DOOR_FADE_MS = 220;

function navigateTo(target) {
  goToPage(target);
  history.replaceState(null, '', `#${target}`);
}

function playDoorTransition(target) {
  if (!doorOverlay || prefersReducedMotion) {
    navigateTo(target);
    return;
  }

  doorOverlay.classList.add('active');
  void doorOverlay.offsetWidth; // força o reflow antes de iniciar a abertura

  // As folhas giram na dobradiça e a cena avança um pouco, como se estivéssemos entrando
  doorOverlay.classList.add('opening');

  setTimeout(() => {
    navigateTo(target);
    doorOverlay.classList.add('closing');

    setTimeout(() => {
      doorOverlay.classList.add('no-transition');
      doorOverlay.classList.remove('active', 'opening', 'closing');
      void doorOverlay.offsetWidth;
      doorOverlay.classList.remove('no-transition');
    }, DOOR_FADE_MS);
  }, DOOR_OPEN_MS);
}

navLinks.forEach(link => {
  link.addEventListener('click', (event) => {
    event.preventDefault();
    const target = link.dataset.nav;

    if (target === 'loja') {
      playDoorTransition(target);
    } else {
      navigateTo(target);
      if (target === 'carrinho') loadCart();
      if (target === 'personalizar') renderCustomForm(null);
    }
  });
});

// Abre direto na seção certa se a URL já tiver um #hash (ex: link compartilhado)
const initial = window.location.hash.replace('#', '') || 'home';
if (document.getElementById(initial)) {
  goToPage(initial);
}

// ---------- Login com Google ----------

const supabaseClient = window.supabase.createClient(SUPABASE_URL, SUPABASE_PUBLISHABLE_KEY);
const authArea = document.getElementById('authArea');
let currentUser = null;

function renderAuthArea(session) {
  currentUser = session?.user || null;

  if (!authArea) return;

  if (!session) {
    authArea.innerHTML = `
      <button class="auth-btn" id="btnLoginGoogle">
        Entrar com Google
      </button>
    `;
    document.getElementById('btnLoginGoogle').addEventListener('click', () => {
      pedirLogin('loja');
    });
    return;
  }

  const user = session.user;
  const nome = user.user_metadata?.full_name || user.email;
  const avatar = user.user_metadata?.avatar_url;

  authArea.innerHTML = `
    <div class="auth-user">
      ${avatar ? `<img src="${avatar}" alt="" class="auth-avatar">` : ''}
      <span class="auth-name">${nome}</span>
      <button class="auth-logout" id="btnLogout">Sair</button>
    </div>
  `;

  document.getElementById('btnLogout').addEventListener('click', () => {
    supabaseClient.auth.signOut();
  });
}

supabaseClient.auth.onAuthStateChange((_event, session) => {
  renderAuthArea(session);
  refreshCartBadge();
  if (!document.getElementById('carrinho').hidden) {
    loadCart();
  }
  if (session) processarRedirecionamentoPosLogin();
});

supabaseClient.auth.getSession().then(({ data }) => {
  renderAuthArea(data.session);
  refreshCartBadge();
  if (data.session) processarRedirecionamentoPosLogin();
});

// ---------- Loja: busca os produtos no Supabase ----------

const productGrid = document.getElementById('productGrid');
const shopLoading = document.getElementById('shopLoading');
let currentFilter = 'todos';
let allProducts = [];

const CATEGORY_MARKS = {
  cartas: '&#9824;',
  fichas: '&#9679;',
  mesas: '&#9646;',
  acessorios: '&#9733;',
};

const CATEGORY_LABELS = {
  cartas: 'Cartas',
  fichas: 'Fichas',
  mesas: 'Mesas',
  acessorios: 'Acessórios',
};

function formatPrice(value) {
  return Number(value).toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' });
}

function renderProducts() {
  const visible = currentFilter === 'todos'
    ? allProducts
    : allProducts.filter(p => p.category === currentFilter);

  if (visible.length === 0) {
    productGrid.innerHTML = '<p class="shop-loading">Nenhum produto nessa categoria ainda.</p>';
    return;
  }

  productGrid.innerHTML = visible.map(product => `
    <article class="product-card" data-category="${product.category}">
      <div class="product-open" data-view-product="${product.id}">
        <div class="product-thumb" aria-hidden="true">
          ${product.tag ? `<span class="product-tag">${product.tag}</span>` : ''}
          ${product.image_url
            ? `<img src="${product.image_url}" alt="" class="thumb-image">`
            : `<span class="thumb-mark">${CATEGORY_MARKS[product.category] || '&#9670;'}</span>`
          }
        </div>
        <div class="product-body">
          <span class="product-category">${CATEGORY_LABELS[product.category] || product.category}</span>
          <h2 class="product-name">${product.name}</h2>
          <p class="product-desc">${product.description || ''}</p>
          <div class="product-foot">
            <span class="product-price">${formatPrice(product.price)}</span>
            ${product.stock > 0
              ? `<span class="product-stock">${product.stock} em estoque</span>`
              : `<span class="product-stock product-stock-out">Esgotado</span>`
            }
          </div>
        </div>
      </div>
      <button class="product-add-cart" data-add-cart="${product.id}" ${product.stock > 0 ? '' : 'disabled'}>
        ${product.stock > 0 ? 'Adicionar ao carrinho' : 'Indisponível'}
      </button>
    </article>
  `).join('');
}

async function loadProducts() {
  const { data, error } = await supabaseClient
    .from('products')
    .select('*')
    .order('created_at', { ascending: true });

  if (error) {
    productGrid.innerHTML = '<p class="shop-loading">Não foi possível carregar os produtos agora.</p>';
    console.error('Erro ao buscar produtos:', error);
    return;
  }

  allProducts = data;
  renderProducts();
}

const filters = document.querySelectorAll('.filter');

filters.forEach(btn => {
  btn.addEventListener('click', () => {
    filters.forEach(b => b.classList.remove('active'));
    btn.classList.add('active');
    currentFilter = btn.dataset.filter;
    renderProducts();
  });
});

loadProducts();

productGrid.addEventListener('click', (event) => {
  const addBtn = event.target.closest('[data-add-cart]');
  if (addBtn) {
    addToCart(addBtn.dataset.addCart);
    return;
  }

  const openBtn = event.target.closest('[data-view-product]');
  if (openBtn) abrirProduto(openBtn.dataset.viewProduct);
});

// ---------- Carrinho ----------

const cartBadge = document.getElementById('cartBadge');
const cartBody = document.getElementById('cartBody');
const cartSub = document.getElementById('cartSub');

async function refreshCartBadge() {
  if (!cartBadge) return;

  if (!currentUser) {
    cartBadge.hidden = true;
    return;
  }

  const { data } = await supabaseClient
    .from('cart_items')
    .select('quantity')
    .eq('user_id', currentUser.id);

  const total = (data || []).reduce((sum, item) => sum + item.quantity, 0);

  if (total > 0) {
    cartBadge.textContent = total;
    cartBadge.hidden = false;
  } else {
    cartBadge.hidden = true;
  }
}

function pedirLogin(redirecionarPara) {
  localStorage.setItem('hn_redirect_after_login', redirecionarPara);
  supabaseClient.auth.signInWithOAuth({
    provider: 'google',
    options: { redirectTo: window.location.origin + window.location.pathname },
  });
}

// Depois que o login é confirmado, manda a pessoa pra onde ela queria ir
// (guardado antes de sair pro Google), sem brigar com o hash que o
// Supabase usa pra entregar a sessão.
function processarRedirecionamentoPosLogin() {
  const alvo = localStorage.getItem('hn_redirect_after_login');
  if (!alvo) return;

  localStorage.removeItem('hn_redirect_after_login');
  navigateTo(alvo);
  if (alvo === 'carrinho') loadCart();
}

async function addToCart(productId, quantidade = 1) {
  if (!currentUser) {
    if (confirm('Você precisa entrar com o Google pra adicionar ao carrinho. Entrar agora?')) {
      pedirLogin('loja');
    }
    return;
  }

  const produto = allProducts.find(p => p.id === productId);

  const { data: existente } = await supabaseClient
    .from('cart_items')
    .select('id, quantity')
    .eq('user_id', currentUser.id)
    .eq('product_id', productId)
    .maybeSingle();

  const quantidadeAtual = existente ? existente.quantity : 0;

  if (produto && quantidadeAtual + quantidade > produto.stock) {
    alert(`Só temos ${produto.stock} unidade(s) de "${produto.name}" em estoque.`);
    return;
  }

  if (existente) {
    await supabaseClient.from('cart_items').update({ quantity: existente.quantity + quantidade }).eq('id', existente.id);
  } else {
    await supabaseClient.from('cart_items').insert({ user_id: currentUser.id, product_id: productId, quantity: quantidade });
  }

  refreshCartBadge();
}

async function loadCart() {
  if (!cartBody) return;

  if (!currentUser) {
    cartBody.innerHTML = `
      <div class="cart-signin">
        <p>Entre com sua conta Google pra ver seu carrinho.</p>
        <button class="cart-signin-btn" id="cartSigninBtn">Entrar com Google</button>
      </div>
    `;
    document.getElementById('cartSigninBtn').addEventListener('click', () => pedirLogin('carrinho'));
    if (cartSub) cartSub.textContent = 'Seus itens selecionados';
    return;
  }

  cartBody.innerHTML = '<p class="shop-loading">Carregando...</p>';

  const { data, error } = await supabaseClient
    .from('cart_items')
    .select('id, quantity, products(id, name, price, image_url, category, stock)')
    .eq('user_id', currentUser.id)
    .order('created_at', { ascending: true });

  if (error) {
    cartBody.innerHTML = '<p class="shop-loading">Não foi possível carregar o carrinho.</p>';
    console.error('Erro ao buscar carrinho:', error);
    return;
  }

  if (!data || data.length === 0) {
    cartBody.innerHTML = `
      <p class="cart-empty">
        Seu carrinho está vazio.
        <a href="#loja" class="cart-empty-link" data-nav="loja">Ver produtos</a>
      </p>
    `;
    if (cartSub) cartSub.textContent = 'Seus itens selecionados';
    return;
  }

  const total = data.reduce((sum, item) => sum + (item.products.price * item.quantity), 0);
  if (cartSub) cartSub.textContent = `${data.length} ${data.length === 1 ? 'item' : 'itens'}`;

  const linhas = data.map(item => `
    <div class="cart-item">
      <div class="cart-item-thumb">
        ${item.products.image_url
          ? `<img src="${item.products.image_url}" alt="">`
          : `<span class="thumb-mark">${CATEGORY_MARKS[item.products.category] || '&#9670;'}</span>`
        }
      </div>
      <div class="cart-item-info">
        <div class="cart-item-name">${item.products.name}</div>
        <div class="cart-item-price">${formatPrice(item.products.price)} cada</div>
      </div>
      <div class="cart-qty">
        <button data-qty-down="${item.id}">−</button>
        <span>${item.quantity}</span>
        <button data-qty-up="${item.id}">+</button>
      </div>
      <button class="cart-item-remove" data-remove="${item.id}">Remover</button>
    </div>
  `).join('');

  cartBody.innerHTML = linhas + `
    <div class="cart-summary">
      <span class="cart-total">${formatPrice(total)}</span>
      <button class="cart-checkout" id="btnCheckout">Finalizar pedido</button>
    </div>
  `;
}

async function mudarQuantidade(cartId, delta) {
  const { data } = await supabaseClient
    .from('cart_items')
    .select('quantity, products(name, stock)')
    .eq('id', cartId)
    .maybeSingle();

  if (!data) return;

  const novaQtd = data.quantity + delta;

  if (delta > 0 && novaQtd > data.products.stock) {
    alert(`Só temos ${data.products.stock} unidade(s) de "${data.products.name}" em estoque.`);
    return;
  }

  if (novaQtd <= 0) {
    await supabaseClient.from('cart_items').delete().eq('id', cartId);
  } else {
    await supabaseClient.from('cart_items').update({ quantity: novaQtd }).eq('id', cartId);
  }

  await loadCart();
  await refreshCartBadge();
}

async function removerDoCarrinho(cartId) {
  await supabaseClient.from('cart_items').delete().eq('id', cartId);
  await loadCart();
  await refreshCartBadge();
}

async function finalizarPedido() {
  if (!currentUser) return;

  const botao = document.getElementById('btnCheckout');
  if (botao) {
    botao.disabled = true;
    botao.textContent = 'Finalizando...';
  }

  const { data, error } = await supabaseClient.rpc('finalizar_pedido');

  if (error) {
    alert('Não foi possível finalizar o pedido: ' + error.message);
    if (botao) {
      botao.disabled = false;
      botao.textContent = 'Finalizar pedido';
    }
    return;
  }

  await loadCart();
  await refreshCartBadge();
  await loadProducts(); // atualiza o estoque mostrado na Loja

  // Manda o e-mail de confirmação — se falhar, não atrapalha o cliente,
  // só registra no console (o pedido já foi feito de qualquer forma).
  supabaseClient.functions.invoke('send-order-confirmation', { body: { orderId: data } })
    .catch(err => console.error('Falha ao enviar e-mail de confirmação:', err));

  alert('Pedido confirmado! Número do pedido: ' + data);
}

if (cartBody) {
  cartBody.addEventListener('click', (event) => {
    const up = event.target.closest('[data-qty-up]');
    const down = event.target.closest('[data-qty-down]');
    const remover = event.target.closest('[data-remove]');
    const checkout = event.target.closest('#btnCheckout');
    const irParaLoja = event.target.closest('[data-nav="loja"]');

    if (up) mudarQuantidade(up.dataset.qtyUp, 1);
    else if (down) mudarQuantidade(down.dataset.qtyDown, -1);
    else if (remover) removerDoCarrinho(remover.dataset.remove);
    else if (checkout) finalizarPedido();
    else if (irParaLoja) {
      event.preventDefault();
      playDoorTransition('loja');
    }
  });
}

// Se a página já abrir direto no carrinho (ex: link compartilhado ou reload),
// carrega o conteúdo agora que tudo já foi declarado.
if (initial === 'carrinho') {
  loadCart();
}

// ---------- Página de detalhe do produto ----------

const produtoContent = document.getElementById('produtoContent');

if (produtoContent) {
  produtoContent.addEventListener('click', (event) => {
    const voltar = event.target.closest('[data-nav="loja"]');
    if (voltar) {
      event.preventDefault();
      playDoorTransition('loja');
      return;
    }

    const personalizar = event.target.closest('[data-personalizar]');
    if (personalizar) {
      event.preventDefault();
      navigateTo('personalizar');
      renderCustomForm(personalizar.dataset.personalizar);
    }
  });
}

function abrirProduto(id) {
  navigateTo('produto');
  renderProdutoDetalhe(id);
}

function renderProdutoDetalhe(id) {
  if (!produtoContent) return;

  const produto = allProducts.find(p => p.id === id);

  if (!produto) {
    produtoContent.innerHTML = `
      <a href="#loja" class="produto-back" data-nav="loja">&larr; Voltar à loja</a>
      <p class="shop-loading">Não encontramos esse produto.</p>
    `;
    return;
  }

  produtoContent.innerHTML = `
    <a href="#loja" class="produto-back" data-nav="loja">&larr; Voltar à loja</a>

    <div class="produto-layout">
      <div class="produto-media">
        ${produto.image_url
          ? `<img src="${produto.image_url}" alt="${produto.name}" class="produto-image">`
          : `<div class="produto-image-placeholder"><span class="thumb-mark">${CATEGORY_MARKS[produto.category] || '&#9670;'}</span></div>`
        }
      </div>

      <div class="produto-info">
        <span class="product-category">${CATEGORY_LABELS[produto.category] || produto.category}</span>
        <h1 class="produto-title">${produto.name}</h1>
        ${produto.tag ? `<span class="product-tag produto-tag-inline">${produto.tag}</span>` : ''}
        <p class="produto-desc">${produto.description || 'Sem descrição disponível.'}</p>

        <div class="produto-price-row">
          <span class="produto-price">${formatPrice(produto.price)}</span>
          ${produto.stock > 0
            ? `<span class="product-stock">${produto.stock} em estoque</span>`
            : `<span class="product-stock product-stock-out">Esgotado</span>`
          }
        </div>

        <div class="produto-qty-row">
          <div class="cart-qty">
            <button type="button" id="produtoQtyDown">−</button>
            <span id="produtoQtyValue">1</span>
            <button type="button" id="produtoQtyUp">+</button>
          </div>
          <button class="product-add-cart produto-add-btn" id="produtoAddCart" ${produto.stock > 0 ? '' : 'disabled'}>
            ${produto.stock > 0 ? 'Adicionar ao carrinho' : 'Indisponível'}
          </button>
        </div>

        <a href="#personalizar" class="produto-custom-link" data-personalizar="${produto.id}">
          &#9998; Pedir uma versão personalizada deste produto
        </a>

        <div class="produto-frete">
          <h2 class="produto-frete-title">Calcular frete</h2>
          <div class="frete-form">
            <input type="text" id="freteInput" class="frete-input" placeholder="Seu CEP" maxlength="9" inputmode="numeric">
            <button type="button" id="freteBtn" class="frete-btn">Calcular</button>
          </div>
          <div id="freteResultado" class="frete-resultado"></div>
        </div>
      </div>
    </div>
  `;

  let qtd = 1;
  const qtyValueEl = document.getElementById('produtoQtyValue');

  document.getElementById('produtoQtyDown').addEventListener('click', () => {
    if (qtd > 1) {
      qtd--;
      qtyValueEl.textContent = qtd;
    }
  });

  document.getElementById('produtoQtyUp').addEventListener('click', () => {
    if (qtd < produto.stock) {
      qtd++;
      qtyValueEl.textContent = qtd;
    }
  });

  document.getElementById('produtoAddCart').addEventListener('click', () => {
    addToCart(produto.id, qtd);
  });

  const freteInput = document.getElementById('freteInput');
  document.getElementById('freteBtn').addEventListener('click', () => calcularFrete(freteInput.value));
  freteInput.addEventListener('keydown', (e) => {
    if (e.key === 'Enter') calcularFrete(freteInput.value);
  });
}

// ---------- Personalizar (encomendas sob medida) ----------

const customContent = document.getElementById('customContent');
let arquivosReferencia = [];

function renderCustomForm(produtoPreSelecionadoId) {
  if (!customContent) return;

  if (!currentUser) {
    customContent.innerHTML = `
      <div class="cart-signin">
        <p>Entre com sua conta Google pra fazer uma encomenda personalizada.</p>
        <button class="cart-signin-btn" id="customSigninBtn">Entrar com Google</button>
      </div>
    `;
    document.getElementById('customSigninBtn').addEventListener('click', () => pedirLogin('personalizar'));
    return;
  }

  arquivosReferencia = [];

  const opcoesProdutos = allProducts.map(p =>
    `<option value="${p.id}" ${p.id === produtoPreSelecionadoId ? 'selected' : ''}>${p.name}</option>`
  ).join('');

  customContent.innerHTML = `
    <form class="custom-form" id="customForm">
      <div class="custom-field">
        <label for="customProduto">Produto base</label>
        <select class="custom-select" id="customProduto" required>
          <option value="" disabled ${produtoPreSelecionadoId ? '' : 'selected'}>Escolha um produto...</option>
          ${opcoesProdutos}
        </select>
      </div>

      <div class="custom-field">
        <label for="customDetalhes">Descreva o que você quer</label>
        <textarea class="custom-textarea" id="customDetalhes" placeholder="Ex: quero meu nome gravado nas fichas, em dourado..." required></textarea>
      </div>

      <div class="custom-field">
        <label>Imagens de referência (opcional)</label>
        <label for="customImagens" class="custom-file-btn">Escolher imagens...</label>
        <input type="file" id="customImagens" class="custom-file-input" accept="image/*" multiple>
        <div class="custom-previews" id="customPreviews"></div>
      </div>

      <button type="submit" class="custom-submit" id="customSubmitBtn">Enviar pedido de personalização</button>
    </form>

    <div class="custom-orders-list" id="customOrdersList"></div>
  `;

  document.getElementById('customImagens').addEventListener('change', (e) => {
    arquivosReferencia = Array.from(e.target.files);
    renderCustomPreviews();
  });

  document.getElementById('customForm').addEventListener('submit', enviarEncomenda);

  carregarMinhasEncomendas();
}

function renderCustomPreviews() {
  const container = document.getElementById('customPreviews');
  if (!container) return;

  container.innerHTML = arquivosReferencia.map(file => {
    const url = URL.createObjectURL(file);
    return `<div class="custom-preview-thumb"><img src="${url}" alt=""></div>`;
  }).join('');
}

async function enviarEncomenda(event) {
  event.preventDefault();

  const produtoId = document.getElementById('customProduto').value;
  const detalhes = document.getElementById('customDetalhes').value.trim();
  const botao = document.getElementById('customSubmitBtn');

  if (!produtoId || !detalhes) {
    alert('Escolha um produto e descreva o que você quer.');
    return;
  }

  botao.disabled = true;
  botao.textContent = 'Enviando...';

  const { data: encomenda, error: encomendaError } = await supabaseClient
    .from('custom_orders')
    .insert({ user_id: currentUser.id, product_id: produtoId, details: detalhes })
    .select('id')
    .single();

  if (encomendaError) {
    alert('Não foi possível enviar sua encomenda: ' + encomendaError.message);
    botao.disabled = false;
    botao.textContent = 'Enviar pedido de personalização';
    return;
  }

  // Sobe as imagens de referência, se tiver alguma
  for (const arquivo of arquivosReferencia) {
    const nomeArquivo = `${encomenda.id}/${crypto.randomUUID()}-${arquivo.name}`;

    const { error: uploadError } = await supabaseClient.storage
      .from('custom-order-images')
      .upload(nomeArquivo, arquivo);

    if (!uploadError) {
      const { data: urlData } = supabaseClient.storage
        .from('custom-order-images')
        .getPublicUrl(nomeArquivo);

      await supabaseClient.from('custom_order_images').insert({
        custom_order_id: encomenda.id,
        image_url: urlData.publicUrl,
      });
    }
  }

  // Manda o e-mail de confirmação — melhor esforço, não trava o fluxo se falhar
  supabaseClient.functions.invoke('send-custom-order-confirmation', { body: { customOrderId: encomenda.id } })
    .catch(err => console.error('Falha ao enviar e-mail de confirmação da encomenda:', err));

  alert('Pedido de personalização enviado! Vamos analisar e te retornar com um orçamento.');
  renderCustomForm(null);
}

const CUSTOM_STATUS_LABELS = {
  pendente: 'Pendente',
  em_analise: 'Em análise',
  orcamento_enviado: 'Orçamento enviado',
  aprovado: 'Aprovado',
  em_producao: 'Em produção',
  concluido: 'Concluído',
  recusado: 'Recusado',
};

async function carregarMinhasEncomendas() {
  const listaEl = document.getElementById('customOrdersList');
  if (!listaEl || !currentUser) return;

  const { data, error } = await supabaseClient
    .from('custom_orders')
    .select('id, details, quoted_price, status, created_at, products(name)')
    .eq('user_id', currentUser.id)
    .order('created_at', { ascending: false });

  if (error || !data || data.length === 0) {
    listaEl.innerHTML = '';
    return;
  }

  listaEl.innerHTML = `
    <p class="custom-orders-title">Minhas encomendas</p>
    ${data.map(encomenda => `
      <div class="custom-order-card">
        <div class="custom-order-top">
          <span class="custom-order-product">${encomenda.products?.name || 'Produto'}</span>
          <span class="custom-order-status custom-order-status-${encomenda.status}">${CUSTOM_STATUS_LABELS[encomenda.status] || encomenda.status}</span>
        </div>
        <p class="custom-order-details">${encomenda.details}</p>
        ${encomenda.quoted_price ? `<p class="custom-order-price">${formatPrice(encomenda.quoted_price)}</p>` : ''}
      </div>
    `).join('')}
  `;
}
// ideia de prazo/valor — não é uma cotação real de transportadora.
const FRETE_REGIOES = {
  '0': { nome: 'São Paulo (capital e região)', prazo: 2, taxa: 18.9 },
  '1': { nome: 'São Paulo (interior)', prazo: 3, taxa: 21.5 },
  '2': { nome: 'Rio de Janeiro / Espírito Santo', prazo: 4, taxa: 24.9 },
  '3': { nome: 'Minas Gerais', prazo: 4, taxa: 23.5 },
  '4': { nome: 'Bahia / Sergipe', prazo: 6, taxa: 29.9 },
  '5': { nome: 'Pernambuco e região', prazo: 7, taxa: 32.5 },
  '6': { nome: 'Norte / Nordeste', prazo: 9, taxa: 36.9 },
  '7': { nome: 'Centro-Oeste / Distrito Federal', prazo: 5, taxa: 27.9 },
  '8': { nome: 'Paraná / Santa Catarina', prazo: 4, taxa: 22.9 },
  '9': { nome: 'Rio Grande do Sul', prazo: 5, taxa: 25.9 },
};

function calcularFrete(cepBruto) {
  const resultadoEl = document.getElementById('freteResultado');
  if (!resultadoEl) return;

  const cep = (cepBruto || '').replace(/\D/g, '');

  if (cep.length !== 8) {
    resultadoEl.innerHTML = '<p class="frete-erro">Digite um CEP válido, com 8 números.</p>';
    return;
  }

  const regiao = FRETE_REGIOES[cep[0]];

  resultadoEl.innerHTML = `
    <div class="frete-linha"><span>Região</span><span>${regiao.nome}</span></div>
    <div class="frete-linha"><span>Prazo estimado</span><span>${regiao.prazo} dia${regiao.prazo > 1 ? 's' : ''} úteis</span></div>
    <div class="frete-linha frete-total"><span>Valor</span><span>${formatPrice(regiao.taxa)}</span></div>
    <p class="frete-aviso">Estimativa aproximada por região — o valor final é confirmado no fechamento do pedido.</p>
  `;
}
