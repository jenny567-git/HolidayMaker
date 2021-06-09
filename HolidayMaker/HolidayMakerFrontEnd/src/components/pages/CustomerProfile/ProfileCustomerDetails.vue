<template >
    <div>
        <h1>{{hotel.reservationId}}</h1>
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
                            <input v-model="info.firstName" type="text" class="form-control" id="firstName" placeholder="Enter first name" >
                        </div>
                    </div>
                    <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                        <div class="form-group">
                            <label for="lastName">Last Name</label>
                            <input v-model="info.lastName" type="text" class="form-control" id="lastName" placeholder="Enter last Name" >
                        </div>
                    </div>
                    <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                        <div class="form-group">
                            <label for="phone">Phone</label>
                            <input v-model="info.phoneNumber" type="text" class="form-control" id="phone" placeholder="Enter phone number" >
                        </div>
                    </div>
                    <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                        <div class="form-group">
                            <label for="email">Email</label>
                            <input v-model="info.email" type="email" class="form-control" id="email" placeholder="Enter email">
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
                            <input v-model="info.street" type="name" class="form-control" id="Street" placeholder="Enter Street">
                        </div>
                    </div>
                    <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                        <div class="form-group">
                            <label for="ciTy">City</label>
                            <input v-model="info.city" type="name" class="form-control" id="ciTy" placeholder="Enter City">
                        </div>
                    </div>
                    <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                        <div class="form-group">
                            <label for="zIp">Zip Code</label>
                            <input v-model="info.zipCode" type="text" class="form-control" id="zIp" placeholder="Zip Code" >
                        </div>
                    </div>
                </div>
                <Button @click="updateReservation" label="Update details" :loading="loading"></Button>
                <div v-if="updated">
                    <h5>
                        Details have been updated
                    </h5>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import BookingMessage from '/src/components/pages/CheckoutViewComponents//BookingMessage.vue'
import Button from 'primevue/button';
export default {
    components:{
        BookingMessage,
        Button,
    },
    props:{
        hotel: {}
    },
    data(){
        return{
            loading: false,
            updated: false
        }
    },
    computed:{
        info(){
            return this.hotel.guestDetails;
        }
    },
    methods:{
        async updateReservation(){
            this.loading = true;
            this.updated = false;
            var response = await fetch("https://localhost:44356/api/Booking/" + this.hotel.reservationId, {
                method: 'PUT',
                headers: { "Content-type": "application/json" },
                body: JSON.stringify(this.info),
            });
            var result = await response.json();

            if(result === 0){
                console.log("saved")
                this.updated = true;
            }
            this.loading = false;
        }
    },
    created(){
        // api to get res details
        // this.Details = this.$store.state.customerDetailsCheckout;
    },
}
</script>
<style scoped>
    label{
        color:black;
    }

    button.p-button.p-component{
  background: #53c16e;
  border:#14a04d;
  text-decoration: none;
}

.p-button:enabled:hover{
  background:#348047 !important;
  border-color:#14a04d;
  text-decoration: none;
}
</style>