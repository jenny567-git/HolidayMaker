<template>
    <div id="test2">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <h3>
                        Checkout
                    </h3>
                </div>
            </div>
            <div class="card p-shadow-1">
                <Steps :model="items" />
            </div>
            <router-view class="" @payment-confirmed="confirmed"/>
            <Button v-if="notAtStart" @click="prevPage" label="Prev" class="p-button-raised p-button-rounded mt-3" />
            <Button v-if="notAtEnd" @click="nextPage" label="Next" class="p-button-raised p-button-rounded mt-3" />
        </div>
    </div>
</template>

<script>
import CustomerDetails from './CheckoutViewComponents/CustomerDetails.vue'
import BookingDetails from './CheckoutViewComponents/BookingDetails.vue'
import Steps from 'primevue/steps';
import Button from 'primevue/button';
export default {
    components:{
        CustomerDetails,
        BookingDetails,
        Steps,
        Button
    },
    computed:{
        notAtStart(){
            return this.page > 0 ? true : false;
        },
        notAtEnd(){
            return this.page < this.items.length - 2 ? true : false;
        },
    },
    data() {
		return {
			items: [{
                label: 'Customer Information',
                to: '/checkout'
            },
            {
                label: 'Order Details',
                to: '/checkout/orderDetails'
            },
            {
                label: 'Payment',
                to: '/checkout/payment'
            },
            {
                label: 'Order Confirmed',
                to: '/checkout/OrderConfirmed'
            },
            ],
            page: 0
		}
	},
    methods:{
        nextPage() {
            if(this.page <= this.items.length - 2){
                this.page++;
                var orderId;
                this.$router.push(this.items[this.page].to);
            }
        },
        prevPage() {
            if(this.page >= 1){
                this.page--;
                this.$router.push(this.items[this.page].to);
            }
        },
        confirmed(id){
            // Set id in vuex
            this.$store.dispatch('setOrderId', id);
            this.nextPage();
        }
    }
}
</script>

<style scoped>
    .h3, h3{
        padding-top: 20px;
    }
    #test2{
        border-radius: 20px;
        background-color: white;
        padding-left: 25px;
        padding-right: 25px;
        padding-bottom: 20px;
        margin-top: 20px;
        color:rgb(255, 255, 255);
        /* text-shadow: 2px 2px black; */
    }

button.p-button.p-component{
  background: #53c16e;
  border:#14a04d;
  text-decoration: none;
}

.p-button:enabled:hover{
  background:#348047 !important;
  border-color:#14a04d;
}

</style>