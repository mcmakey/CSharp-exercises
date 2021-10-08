'use strict';

let fitlerPopup = document.querySelector('.filterPopup');
let fitlerLabel = document.querySelector('.filterLabel');
let filterIcon = document.querySelector('.filterIcon');

fitlerLabel.addEventListener('click', function () {
    fitlerPopup.classList.toggle('hidden');
    fitlerLabel.classList.toggle('filterLabelPink');
    filterIcon.classList.toggle('filterIconPink');

    if (filterIcon.getAttribute('src') === 'images/filter.svg') {
        filterIcon.setAttribute('src', 'images/filterHover.svg');
    } else {
        filterIcon.setAttribute('src', 'images/filter.svg');
    }
});

let filterHeaders = document.querySelectorAll('.filterCategoryHeader');
filterHeaders.forEach(function (header) {
    header.addEventListener('click', function (event) {
        event.target.nextElementSibling.classList.toggle('hidden');
    });
});

let filterSizes = document.querySelector('.filterSizes');
let filterSizeWrap = document.querySelector('.filterSizeWrap');
filterSizeWrap.addEventListener('click', function () {
    filterSizes.classList.toggle('hidden');
});

///////

// cart
const storeCart = cart();

// elements
const buttonsAddToCart = document.querySelectorAll('.js-add-to-cart');
const cartIcon = document.querySelector('.js-cart-icon');

// listeners
buttonsAddToCart.forEach(button => button.addEventListener('click', addToCartClickHandler));
cartIcon.addEventListener('hover', storeCartHoverHandler);

// handlers
function addToCartClickHandler(event) {
    const product = getProduct(event);
    storeCart.add(product);
}

function storeCartHoverHandler() {
    storeCart.show();
}

//
function getProduct(event) {
    const target = event.target;
    const productDataEl = target.closest('.featuredItem').querySelector('.featuredData');

    const productName = productDataEl.querySelector('.featuredName').innerText;
    const productDescription = productDataEl.querySelector('.featuredText').innerText;
    const productPrice = Number(productDataEl.querySelector('.featuredPrice').innerText.slice(1));

    const product = {
        name: productName,
        description: productDescription,
        price: productPrice,
    };

    return product;
}

// cartmodul
function cart() {
    const entries = [];

    const add = product => {
        console.log('add');
        console.log(product);
    };

    const show = () => {
        console.log('show');
    };

    return {
        add: add,
        show: show,
    };
}
