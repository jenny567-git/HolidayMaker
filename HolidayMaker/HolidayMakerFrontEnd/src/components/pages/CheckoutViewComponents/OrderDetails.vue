<template>
    <div>
        <h1>Order details</h1>
        <div class="row">
            <div class="col">
                <Card style="">
                    <template #title>
                    Personal Details
                    </template>
                    <template #content>
                        <ul class="list-group list-group-flush" >
                            <li class="list-group-item leftTexAlignt"><span class="fas fa-user"></span><b> Full name:</b> {{Details.firstName}} {{Details.lastName}}</li>
                            <li class="list-group-item leftTexAlignt"><span class="fas fa-at"></span><b> Email:</b> {{Details.email}}</li>
                            <li class="list-group-item leftTexAlignt"><span class="fas fa-phone"></span><b> Phone:</b> {{Details.phoneNumber}}</li>
                            <li class="list-group-item leftTexAlignt"><span class="fas fa-address-book"></span><b> Address:</b> {{Details.street}}, {{Details.zipCode}}, {{Details.city}}</li>
                        </ul>
                    </template>
                </Card>
            </div>
            <div class="col">
                <Card style="">
                    <template #title>
                    Booking Details
                    </template>
                    <template #content>
                        <ul class="list-group list-group-flush" >
                            <li class="list-group-item leftTexAlignt"><span class="fas fa-hotel"></span><b> Hotel name:</b> {{BookingDetails.hotelName}}</li>
                            <li class="list-group-item leftTexAlignt"><span class="fas fa-check-square"></span><b> Check in:</b> {{checkinDate}}</li>
                            <li class="list-group-item leftTexAlignt"><span class="far fa-check-square"></span><b> Check out:</b> {{checkoutDate}}</li>
                            <li v-if="SearchString.inputChild > 0" class="list-group-item leftTexAlignt"><span class="fas fa-users"></span><b> Number of people:</b> {{SearchString.inputAdult}} adults, {{SearchString.inputChild}} children</li>
                            <li v-else class="list-group-item leftTexAlignt"><span class="fas fa-users"></span><b> Number of people:</b> {{SearchString.inputAdult}} adults</li>
                            <li class="list-group-item leftTexAlignt"><span class="fas fa-concierge-bell"></span><b> Service type:</b> {{BookingDetails.serviceType}}</li>
                            <li v-if="BookingDetails.extraBed" class="list-group-item leftTexAlignt"><span class="fas fa-bed"></span> <b>Extra bed:</b> Yes</li>
                            <li class="list-group-item leftTexAlignt"><span class="fas fa-money-check-alt"></span><b> Total price:</b> {{BookingDetails.totalprice}} SEK</li>
                        </ul>
                        <Button  label="Edit Booking" icon="pi pi-user-edit" @click="$router.push('/hotels/' + $store.state.bookingDetails.hotelId + '/rooms')"></Button>
                        <!-- <router-link :to="link" class="btn btn-secondary">
                            Edit booking
                        </router-link> -->
                    </template>
                </Card>
            </div>
        </div>
        <hr/>
    </div>
</template>
<script>
import Card from 'primevue/card';
import Button from 'primevue/button';

export default {
     components:{
         Card,
         Button,
     },
     data(){
        return{
            Details:{},
            BookingDetails: {},
            SearchString: {},
            link: '/hotels/' + this.$store.state.bookingDetails.hotelId + '/rooms'
        }
    },
    computed:{
        checkinDate(){
            if(this.$store.state.searchString.dates[0] !== undefined){
                console.log("sdasds",this.$store.state.searchString.dates[0]);
                return this.$store.state.searchString.dates[0].toLocaleDateString('sv-SE');
            }else{
                return "not specified"
            }
        },
        checkoutDate(){
           if(this.$store.state.searchString.dates[1]  !== undefined){
                return this.$store.state.searchString.dates[1].toLocaleDateString('sv-SE');
            }else{
                return "not specified"
            }
        }
    },
    created(){
        this.Details = this.$store.state.customerDetailsCheckout;
        console.log("order details cust details: ",this.$store.state.customerDetailsCheckout)
        this.BookingDetails = this.$store.state.bookingDetails;
        this.SearchString = this.$store.state.searchString;
    },
}
</script>
<style scoped>
    .leftTexAlignt{
        text-align: left;
    }
    .CardHolder{
        width: 50%;
        display: block;
    }
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