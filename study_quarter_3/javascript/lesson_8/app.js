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
const cartIconCounter = document.querySelector('.js-cart-icon-counter');
const cartContainer = document.querySelector('.rightHeader');

// listeners
buttonsAddToCart.forEach(button => button.addEventListener('click', addToCartClickHandler));
cartIcon.addEventListener('mouseover', showCart);
cartIcon.addEventListener('mouseout', hideCart);

// handlers
function addToCartClickHandler(event) {
    const product = getProduct(event);
    storeCart.add(product);

    showTotalCountProducts();
}

function showCart(event) {
    const cartEntries = storeCart.getEntries();

    const cartPlate = document.createElement('table');
    cartPlate.className = 'cart-plate';

    const cartPlateHeader = document.createElement('tr');
    appendCell(cartPlateHeader, 'Название товара', 'th');
    appendCell(cartPlateHeader, 'Количество', 'th');
    appendCell(cartPlateHeader, 'Цена за шт.', 'th');
    appendCell(cartPlateHeader, 'Итого', 'th');

    cartPlate.appendChild(cartPlateHeader);

    cartEntries.forEach(entry => {
        const row = document.createElement('tr');

        appendCell(row, entry.name);
        appendCell(row, entry.count);
        appendCell(row, `$${entry.price}`);
        appendCell(row, `$${entry.totalCost}`);

        cartPlate.appendChild(row);
    });

    cartContainer.appendChild(cartPlate);

    function appendCell(row, title, cellTag = 'td') {
        const cell = document.createElement(cellTag);
        cell.innerText = title;
        row.appendChild(cell);
    }
}

function hideCart(event) {
    document.querySelector('.cart-plate').remove();
}

// cartmodul
function cart() {
    const entries = [];

    const add = product => {
        const sameProduct = entries.find(x => x.name == product.name);

        if (sameProduct) {
            sameProduct.count += 1;
        } else {
            const newEntry = new Entry(product);
            entries.push(newEntry);
        }
    };

    const getEntries = () => {
        return entries;
    };

    const getTotalCount = () => {
        const count = entries.reduce((sum, currValue) => {
            return sum + currValue.count;
        }, 0);

        return count;
    };

    return {
        add: add,
        getEntries: getEntries,
        getTotalCount: getTotalCount,
    };
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

function showTotalCountProducts() {
    cartIconCounter.innerText = storeCart.getTotalCount();
}

function Entry(product) {
    this.name = product.name;
    this.count = 1;
    this.price = product.price;

    Object.defineProperties(this, {
        totalCost: {
            get: function () {
                return this.price * this.count;
            },
        },
    });
}
