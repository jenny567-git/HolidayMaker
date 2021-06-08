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
                            <li class="list-group-item leftTexAlignt"> <b>Full name:</b> {{Details.firstName}} {{Details.lastName}}</li>
                            <li class="list-group-item leftTexAlignt"> <b>Email:</b> {{Details.email}}</li>
                            <li class="list-group-item leftTexAlignt"> <b>Phone:</b> {{Details.phoneNumber}}</li>
                            <li class="list-group-item leftTexAlignt"> <b>Address:</b> {{Details.street}}, {{Details.zipCode}}, {{Details.city}}</li>
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
                            <li class="list-group-item leftTexAlignt"> <b>Hotel name:</b> {{BookingDetails.hotelName}}</li>
                            <li class="list-group-item leftTexAlignt"> <b>Check in:</b> {{checkinDate}}</li>
                            <li class="list-group-item leftTexAlignt"> <b>Check out:</b> {{checkoutDate}}</li>
                            <li v-if="SearchString.inputChild > 0" class="list-group-item leftTexAlignt"> <b>Number of people:</b> {{SearchString.inputAdult}} adults, {{SearchString.inputChild}} children</li>
                            <li v-else class="list-group-item leftTexAlignt"> <b>Number of people:</b> {{SearchString.inputAdult}} adults</li>
                            <li class="list-group-item leftTexAlignt"> <b>Service type:</b> {{BookingDetails.serviceType}}</li>
                            <li v-if="BookingDetails.extraBed" class="list-group-item leftTexAlignt"> <b>Extra bed:</b> Yes</li>
                            <li class="list-group-item leftTexAlignt"> <b>Total price:</b> {{BookingDetails.totalprice}}</li>
                        </ul>
                        <router-link :to="link" class="btn btn-primary">
                            Edit booking
                        </router-link>
                    </template>
                </Card>
            </div>
        </div>
        <hr/>
    </div>
</template>
<script>
import Card from 'primevue/card';
export default {
     components:{
         Card,
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
</style>