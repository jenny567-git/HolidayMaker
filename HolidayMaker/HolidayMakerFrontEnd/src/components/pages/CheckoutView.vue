<template>
    <div id="test2">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <h3>
                        Checkout details
                    </h3>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-lg-7">
                    <CustomerDetails> </CustomerDetails>
                </div>

                <div class="col-md-5"> 
                    <BookingDetails> </BookingDetails>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import CustomerDetails from './CheckoutViewComponents/CustomerDetails.vue'
import BookingDetails from './CheckoutViewComponents/BookingDetails.vue'
export default {
    components:{
        CustomerDetails,
        BookingDetails
    },
    
}
</script>

<style scoped>
    .h3, h3{
        padding-top: 20px;
    }
    #test2{
        border-radius: 30px;
        background-color: white;
        padding-left: 25px;
        padding-right: 25px;
        padding-bottom: 40px;
        margin-top: 20px;
        color:rgb(255, 255, 255);
        /* text-shadow: 2px 2px black; */
    }

</style>