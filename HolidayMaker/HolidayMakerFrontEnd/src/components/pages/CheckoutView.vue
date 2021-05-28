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
            <div class="card">
                <Steps :model="items" />
            </div>
            <router-view />
            <button class="btn btn-primary" v-if="notAtStart" @click="prevPage">Prev</Button>
            <button class="btn btn-primary" v-if="notAtEnd" @click="nextPage">Next</button>
        </div>
    </div>
</template>

<script>
import CustomerDetails from './CheckoutViewComponents/CustomerDetails.vue'
import BookingDetails from './CheckoutViewComponents/BookingDetails.vue'
import Steps from 'primevue/steps';
export default {
    components:{
        CustomerDetails,
        BookingDetails,
        Steps,
    },
    computed:{
        notAtStart(){
            return this.page > 0 ? true : false;
        },
        notAtEnd(){
            return this.page < this.items.length - 1 ? true : false;
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
                label: 'Confirmation',
                to: '/checkout/orderCompleted'
            },
            ],
            page: 0
		}
	},
    methods:{
        nextPage() {
            if(this.page <= this.items.length - 2){
                this.page++;
                this.$router.push(this.items[this.page].to);
            }
        },
        prevPage() {
            if(this.page >= 1){
                this.page--;
                this.$router.push(this.items[this.page].to);
            }
        },
    }
    
}
</script>

<style scoped>
    .h3, h3{
        padding-top: 20px;
    }
    #test2{
        border-radius: 30px;
        background-color: rgba(107, 146, 83, 0.5);
        padding-left: 25px;
        padding-right: 25px;
        padding-bottom: 40px;
        margin-top: 20px;
        color:rgb(255, 255, 255);
        /* text-shadow: 2px 2px black; */
    }

</style>