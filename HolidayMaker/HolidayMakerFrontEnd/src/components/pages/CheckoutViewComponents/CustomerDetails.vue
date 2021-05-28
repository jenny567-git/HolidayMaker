<template >
    <div>
        <h4 class="mb-3">Billing address</h4>
        <form asp-action="AddOrder" class="form-horizontal" id="CheckoutForm">
            <div class="row g-3">
                <div class="col-sm-6">
                    <label class="control-label">First Name</label>
                    <input v-model="Details.FirstName" type="text" class="form-control" @input="save"/>
                </div>

                <div class="col-sm-6">
                    <label class="control-label">Last Name</label>
                    <input v-model="Details.LastName" type="text" class="form-control" @input="save" />
                </div>

                <div class="col-12">
                    <label class="control-label">Email</label>
                    <input v-model="Details.Email" type="email" class="form-control" @input="save" />
                </div>

                <div class="col-12">
                    <label class="control-label">Street</label>
                    <input v-model="Details.Street" type="text" class="form-control" @input="save"/>
                </div>

                <div class="col-md-5">
                    <label class="control-label">Phone number</label>
                    <input v-model="Details.PhoneNumber" type="tel" class="form-control" @input="save"/> 
                </div>

                <div class="col-md-4">
                    <label class="control-label">City</label>
                    <input v-model="Details.City" type="text" class="form-control" @input="save"/>
                </div>

                <div class="col-md-3">
                    <label class="control-label">Zip Code</label>
                    <input v-model="Details.ZipCode" type="number" class="form-control" @input="save"/>
                </div>
            </div>

            <hr class="my-4">
        </form>  
    </div>
</template>

<script>
export default {
    data(){
        return{
            Details:{
                FirstName: '',
                LastName: '',
                Email: '',
                Street: '',
                PhoneNumber: '',
                City: '',
                ZipCode: '',
            }
        }
    },
    methods:{
        save(){
            this.$store.dispatch('saveCustomerDetailsCheckout', this.Details);
        }
    },
    created(){
        this.Details = this.$store.state.customerDetailsCheckout;
    }
    
}
</script>
<style >
    
</style>