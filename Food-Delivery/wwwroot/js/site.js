// Food Delivery App JavaScript

// Cart functionality
let cart = JSON.parse(localStorage.getItem('cart')) || [];
updateCartUI();

// Add item to cart
function addToCart(id, name, price, image = null) {
    const existingItem = cart.find(item => item.id === id);
    
    if (existingItem) {
        existingItem.quantity += 1;
    } else {
        cart.push({
            id: id,
            name: name,
            price: price,
            image: image,
            quantity: 1
        });
    }
    
    localStorage.setItem('cart', JSON.stringify(cart));
    updateCartUI();
    showToast(`${name} added to cart!`, 'success');
}

// Remove item from cart
function removeFromCart(id) {
    cart = cart.filter(item => item.id !== id);
    localStorage.setItem('cart', JSON.stringify(cart));
    updateCartUI();
    renderCartItems();
}

// Update quantity
function updateQuantity(id, change) {
    const item = cart.find(item => item.id === id);
    if (item) {
        item.quantity += change;
        if (item.quantity <= 0) {
            removeFromCart(id);
        } else {
            localStorage.setItem('cart', JSON.stringify(cart));
            updateCartUI();
            renderCartItems();
        }
    }
}

// Update cart UI
function updateCartUI() {
    const cartCount = cart.reduce((total, item) => total + item.quantity, 0);
    const cartTotal = cart.reduce((total, item) => total + (item.price * item.quantity), 0);
    
    document.getElementById('cart-count').textContent = cartCount;
    if (document.getElementById('cart-total')) {
        document.getElementById('cart-total').textContent = cartTotal.toFixed(2);
    }
}

// Show cart modal
function showCart() {
    renderCartItems();
    const cartModal = new bootstrap.Modal(document.getElementById('cartModal'));
    cartModal.show();
}

// Render cart items
function renderCartItems() {
    const cartItemsContainer = document.getElementById('cart-items');
    
    if (cart.length === 0) {
        cartItemsContainer.innerHTML = '<p class="text-center text-muted">Your cart is empty</p>';
        return;
    }
    
    cartItemsContainer.innerHTML = cart.map(item => `
        <div class="cart-item">
            <div class="row align-items-center">
                <div class="col-md-6">
                    <h6 class="mb-1">${item.name}</h6>
                    <small class="text-muted">₹${item.price} each</small>
                </div>
                <div class="col-md-3">
                    <div class="quantity-controls">
                        <button class="quantity-btn" onclick="updateQuantity(${item.id}, -1)">
                            <i class="fas fa-minus"></i>
                        </button>
                        <span class="mx-2">${item.quantity}</span>
                        <button class="quantity-btn" onclick="updateQuantity(${item.id}, 1)">
                            <i class="fas fa-plus"></i>
                        </button>
                    </div>
                </div>
                <div class="col-md-2 text-end">
                    <strong>₹${(item.price * item.quantity).toFixed(2)}</strong>
                </div>
                <div class="col-md-1 text-end">
                    <button class="btn btn-sm btn-outline-danger" onclick="removeFromCart(${item.id})">
                        <i class="fas fa-trash"></i>
                    </button>
                </div>
            </div>
        </div>
    `).join('');
}

// Checkout function
function checkout() {
    if (cart.length === 0) {
        showToast('Your cart is empty!', 'warning');
        return;
    }
    
    // Show checkout form
    showCheckoutForm();
}

// Show checkout form
function showCheckoutForm() {
    const total = cart.reduce((total, item) => total + (item.price * item.quantity), 0);
    
    const checkoutHTML = `
        <div class="modal fade" id="checkoutModal" tabindex="-1" aria-labelledby="checkoutModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header bg-success text-white">
                        <h5 class="modal-title" id="checkoutModalLabel">
                            <i class="fas fa-credit-card me-2"></i>Checkout
                        </h5>
                        <button type="button" class="btn-close btn-close-white" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <form id="checkoutForm">
                            <div class="mb-3">
                                <label for="customerName" class="form-label">Full Name</label>
                                <input type="text" class="form-control" id="customerName" required>
                            </div>
                            <div class="mb-3">
                                <label for="customerPhone" class="form-label">Phone Number</label>
                                <input type="tel" class="form-control" id="customerPhone" required>
                            </div>
                            <div class="mb-3">
                                <label for="deliveryAddress" class="form-label">Delivery Address</label>
                                <textarea class="form-control" id="deliveryAddress" rows="3" required></textarea>
                            </div>
                            <div class="border-top pt-3">
                                <h6>Order Summary:</h6>
                                <div id="checkout-items">
                                    ${cart.map(item => `
                                        <div class="d-flex justify-content-between mb-2">
                                            <span>${item.name} x${item.quantity}</span>
                                            <span>₹${(item.price * item.quantity).toFixed(2)}</span>
                                        </div>
                                    `).join('')}
                                </div>
                                <hr>
                                <div class="d-flex justify-content-between fw-bold">
                                    <span>Total:</span>
                                    <span>₹${total.toFixed(2)}</span>
                                </div>
                            </div>
                        </form>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancel</button>
                        <button type="button" class="btn btn-success" onclick="processOrder()">
                            <i class="fas fa-check me-2"></i>Place Order
                        </button>
                    </div>
                </div>
            </div>
        </div>
    `;
    
    // Remove existing checkout modal if any
    const existingModal = document.getElementById('checkoutModal');
    if (existingModal) {
        existingModal.remove();
    }
    
    document.body.insertAdjacentHTML('beforeend', checkoutHTML);
    
    // Hide cart modal and show checkout modal
    const cartModal = bootstrap.Modal.getInstance(document.getElementById('cartModal'));
    if (cartModal) {
        cartModal.hide();
    }
    
    const checkoutModal = new bootstrap.Modal(document.getElementById('checkoutModal'));
    checkoutModal.show();
}

// Process order
function processOrder() {
    const customerName = document.getElementById('customerName').value.trim();
    const customerPhone = document.getElementById('customerPhone').value.trim();
    const deliveryAddress = document.getElementById('deliveryAddress').value.trim();
    
    if (!customerName || !customerPhone || !deliveryAddress) {
        showToast('Please fill in all required fields', 'warning');
        return;
    }
    
    const total = cart.reduce((total, item) => total + (item.price * item.quantity), 0);
    
    const orderData = {
        customerName: customerName,
        phone: customerPhone,
        deliveryAddress: deliveryAddress,
        total: total,
        items: cart
    };
    
    // Simulate API call
    showToast('Processing your order...', 'info');
    
    // Simulate order placement
    setTimeout(() => {
        const orderId = Math.floor(Math.random() * 9000) + 1000;
        
        // Clear cart
        cart = [];
        localStorage.setItem('cart', JSON.stringify(cart));
        updateCartUI();
        
        // Hide checkout modal
        const checkoutModal = bootstrap.Modal.getInstance(document.getElementById('checkoutModal'));
        if (checkoutModal) {
            checkoutModal.hide();
        }
        
        // Show success message
        showOrderConfirmation(orderId, orderData);
        
    }, 2000);
}

// Show order confirmation
function showOrderConfirmation(orderId, orderData) {
    const confirmationHTML = `
        <div class="modal fade" id="confirmationModal" tabindex="-1" aria-labelledby="confirmationModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header bg-success text-white">
                        <h5 class="modal-title" id="confirmationModalLabel">
                            <i class="fas fa-check-circle me-2"></i>Order Confirmed!
                        </h5>
                        <button type="button" class="btn-close btn-close-white" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body text-center">
                        <div class="mb-4">
                            <i class="fas fa-check-circle text-success" style="font-size: 4rem;"></i>
                        </div>
                        <h4>Thank you, ${orderData.customerName}!</h4>
                        <p class="text-muted mb-4">Your order has been confirmed and is being prepared.</p>
                        
                        <div class="border rounded p-3 mb-4">
                            <h6>Order Details:</h6>
                            <p class="mb-1"><strong>Order ID:</strong> #${orderId}</p>
                            <p class="mb-1"><strong>Total:</strong> ₹${orderData.total.toFixed(2)}</p>
                            <p class="mb-1"><strong>Delivery Address:</strong> ${orderData.deliveryAddress}</p>
                            <p class="mb-0"><strong>Phone:</strong> ${orderData.phone}</p>
                        </div>
                        
                        <div class="alert alert-info">
                            <i class="fas fa-clock me-2"></i>
                            Estimated delivery time: 30-45 minutes
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-primary" data-bs-dismiss="modal">Continue Shopping</button>
                    </div>
                </div>
            </div>
        </div>
    `;
    
    document.body.insertAdjacentHTML('beforeend', confirmationHTML);
    
    const confirmationModal = new bootstrap.Modal(document.getElementById('confirmationModal'));
    confirmationModal.show();
    
    // Auto remove modal after it's hidden
    document.getElementById('confirmationModal').addEventListener('hidden.bs.modal', function() {
        this.remove();
    });
}

// Toast notification function
function showToast(message, type = 'info') {
    // Create toast container if it doesn't exist
    let toastContainer = document.getElementById('toast-container');
    if (!toastContainer) {
        toastContainer = document.createElement('div');
        toastContainer.id = 'toast-container';
        toastContainer.className = 'position-fixed top-0 end-0 p-3';
        toastContainer.style.zIndex = '9999';
        document.body.appendChild(toastContainer);
    }
    
    // Create toast
    const toastId = 'toast-' + Date.now();
    const toastHTML = `
        <div id="${toastId}" class="toast show" role="alert" aria-live="assertive" aria-atomic="true">
            <div class="toast-header bg-${type} text-white">
                <i class="fas fa-${getToastIcon(type)} me-2"></i>
                <strong class="me-auto">FoodieExpress</strong>
                <button type="button" class="btn-close btn-close-white" data-bs-dismiss="toast" aria-label="Close"></button>
            </div>
            <div class="toast-body">
                ${message}
            </div>
        </div>
    `;
    
    toastContainer.insertAdjacentHTML('beforeend', toastHTML);
    
    // Auto remove toast after 3 seconds
    setTimeout(() => {
        const toastElement = document.getElementById(toastId);
        if (toastElement) {
            toastElement.remove();
        }
    }, 3000);
}

// Get toast icon based on type
function getToastIcon(type) {
    switch(type) {
        case 'success': return 'check-circle';
        case 'error': return 'exclamation-circle';
        case 'warning': return 'exclamation-triangle';
        case 'info': return 'info-circle';
        default: return 'info-circle';
    }
}

// Search functionality
function searchRestaurants(term) {
    // This would typically make an API call
    console.log('Searching for:', term);
}

// Initialize on page load
document.addEventListener('DOMContentLoaded', function() {
    // Add smooth scrolling to all links
    document.querySelectorAll('a[href^="#"]').forEach(anchor => {
        anchor.addEventListener('click', function (e) {
            e.preventDefault();
            document.querySelector(this.getAttribute('href')).scrollIntoView({
                behavior: 'smooth'
            });
        });
    });
    
    // Add fade-in animation to cards
    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.classList.add('fade-in');
            }
        });
    });
    
    document.querySelectorAll('.restaurant-card, .menu-item-card, .feature-box').forEach(el => {
        observer.observe(el);
    });
});
