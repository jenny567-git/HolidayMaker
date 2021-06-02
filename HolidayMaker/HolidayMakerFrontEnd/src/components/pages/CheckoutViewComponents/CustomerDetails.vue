<template >
    <div>
        <h4 class="mb-3">Billing address</h4>
        <div class="card h-100">
            <div class="card-body">
                <div class="row gutters">
                    <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                        <h6 class="mb-2 text-primary">Personal Details</h6>
                    </div>
                    <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                        <div class="form-group">
                            <label for="firstName">First Name</label>
                            <input v-model="Details.FirstName" type="text" class="form-control" id="firstName" placeholder="Enter first name" @input="save">
                        </div>
                    </div>
                    <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                        <div class="form-group">
                            <label for="lastName">Last Name</label>
                            <input v-model="Details.LastName" type="text" class="form-control" id="lastName" placeholder="Enter last Name" @input="save">
                        </div>
                    </div>
                    <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                        <div class="form-group">
                            <label for="phone">Phone</label>
                            <input v-model="Details.PhoneNumber" type="number" class="form-control" id="phone" placeholder="Enter phone number" @input="save">
                        </div>
                    </div>
                    <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                        <div class="form-group">
                            <label for="email">Email</label>
                            <input v-model="Details.Email" type="email" class="form-control" id="email" placeholder="Enter email" @input="save">
                        </div>
                    </div>
                </div>
                <div class="row gutters">
                    <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                        <h6 class="mt-3 mb-2 text-primary">Address</h6>
                    </div>
                    <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                        <div class="form-group">
                            <label for="Street">Street</label>
                            <input v-model="Details.Street" type="name" class="form-control" id="Street" placeholder="Enter Street" @input="save">
                        </div>
                    </div>
                    <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                        <div class="form-group">
                            <label for="ciTy">City</label>
                            <input v-model="Details.City" type="name" class="form-control" id="ciTy" placeholder="Enter City" @input="save">
                        </div>
                    </div>
                    <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                        <div class="form-group">
                            <label for="sTate">State</label>
                            <input v-model="Details.State" type="text" class="form-control" id="sTate" placeholder="Enter State" @input="save">
                        </div>
                    </div>
                    <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                        <div class="form-group">
                            <label for="zIp">Zip Code</label>
                            <input v-model="Details.ZipCode" type="text" class="form-control" id="zIp" placeholder="Zip Code" @input="save">
                        </div>
                    </div>
                </div>
                <!-- <div class="row gutters">
                    <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                        <div class="text-right">
                            <button type="button" id="submit" name="submit" class="btn btn-secondary">Cancel</button>
                            <button type="button" id="submit" name="submit" class="btn btn-primary">Update</button>
                        </div>
                    </div>
                </div> -->
            </div>
        </div>
        <hr/> 
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
                State: '',
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
<style scoped>
    label{
        color:black;
    }
</style>