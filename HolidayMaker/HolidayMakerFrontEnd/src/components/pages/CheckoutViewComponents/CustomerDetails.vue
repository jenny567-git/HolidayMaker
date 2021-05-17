<template >
    <div>
        <h4 class="mb-3">Billing address</h4>
        <form asp-action="AddOrder" class="form-horizontal" id="CheckoutForm">
                    <div class="row g-3">
                        <div class="col-sm-6">
                            <label class="control-label">First Name</label>
                            <input type="text" class="form-control" />
                            
                        </div>

                        <div class="col-sm-6">
                            <label class="control-label">Last Name</label>
                            <input type="text" class="form-control" />
                            
                        </div>

                        <div class="col-12">
                            <label class="control-label">Email</label>
                            <input type="email" class="form-control" />
                            
                        </div>

                        <div class="col-12">
                            <label class="control-label">Street</label>
                            <input type="text" class="form-control" />
                            
                        </div>

                        <div class="col-md-5">
                            <label class="control-label">Phone number</label>
                            <input type="tel" class="form-control" />
                            
                        </div>

                        <div class="col-md-4">
                            <label class="control-label">City</label>
                            <input type="text" class="form-control" />
                            
                        </div>

                        <div class="col-md-3">
                            <label class="control-label">Zip Code</label>
                            <input type="number" class="form-control" />
                            
                        </div>
                    </div>

                    <hr class="my-4">

                    <div class="form-check">
                        <input type="checkbox" class="form-check-input" id="same-address">
                        <label class="form-check-label" for="same-address">Shipping address is the same as my billing address</label>
                    </div>

                    <div class="form-check">
                        <input type="checkbox" class="form-check-input" id="save-info">
                        <label class="form-check-label" for="save-info">Save this information for next time</label>
                    </div>

                    <hr class="my-4">

                    <h4 class="mb-3">Payment</h4>

                    <div class="my-3">
                        <div class="form-check">
                            <input id="credit" name="paymentMethod" type="radio" class="form-check-input" checked required>
                            <label class="form-check-label" for="credit">Credit card</label>
                        </div>
                        <div class="form-check">
                            <input id="debit" name="paymentMethod" type="radio" class="form-check-input" required>
                            <label class="form-check-label" for="debit">Debit card</label>
                        </div>
                        <div class="form-check">
                            <input id="paypal" name="paymentMethod" type="radio" class="form-check-input" required>
                            <label class="form-check-label" for="paypal">PayPal</label>
                        </div>
                    </div>

                    <div class="row gy-3">
                        <div class="col-md-6">
                            <label for="cc-name" class="form-label">Name on card</label>
                            <input type="text" class="form-control" id="cc-name" placeholder="" required>
                            <small class="text-muted">Full name as displayed on card</small>
                            <div class="invalid-feedback">
                                Name on card is required
                            </div>
                        </div>

                        <div class="col-md-6">
                            <label for="cc-number" class="form-label">Credit card number</label>
                            <input type="text" class="form-control" id="cc-number" placeholder="" required>
                            <div class="invalid-feedback">
                                Credit card number is required
                            </div>
                        </div>

                        <div class="col-md-3">
                            <label for="cc-expiration" class="form-label">Expiration</label>
                            <input type="text" class="form-control" id="cc-expiration" placeholder="" required>
                            <div class="invalid-feedback">
                                Expiration date required
                            </div>
                        </div>

                        <div class="col-md-3">
                            <label for="cc-cvv" class="form-label">CVV</label>
                            <input type="text" class="form-control" id="cc-cvv" placeholder="" required>
                            <div class="invalid-feedback">
                                Security code required
                            </div>
                        </div>
                    </div>

                    <hr class="my-4">
                        <button id="CheckoutBtn" class="w-100 btn btn-primary btn-lg" type="submit" value="Submit">Checkout</button>
                    <div class="form-group">

                    </div>
        </form>  
    </div>
</template>

<script>
export default {
    
}
</script>
<style >
    
</style>