<template >
    <div>
        
        <Card class="cardStyle">
            <template #title>
                Order successful!
            </template>
            <template #content>
                <img alt="Bootstrap Image Preview" src="https://raw.githubusercontent.com/PKief/vscode-markdown-checkbox/master/logo.png" class="rounded-circle" id="orderPic"/>
                <router-link :to="'/reservationDetails/' + orderLink">Click here to go to your order page!</router-link>
            </template>
        </Card>
    </div>
</template>
<script>
import Card from 'primevue/card';
export default {
    components:{
        Card,
    },
    computed:{
        orderLink(){
            return this.$store.state.orderId;
        }
    },
}
</script>
<style scoped>
    #orderPic {
        width: 100px;
        height: 100px;
    }
    .cardStyle{
        margin-top: 30px;
    }
</style>