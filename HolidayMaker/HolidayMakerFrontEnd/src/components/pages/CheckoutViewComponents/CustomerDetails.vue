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


        </form>  
    </div>
</template>

<script>
export default {
    
}
</script>
<style >
    
</style>