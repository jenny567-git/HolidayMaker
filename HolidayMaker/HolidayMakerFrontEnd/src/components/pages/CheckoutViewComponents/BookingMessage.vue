<template >
    <div>
        <div class="row g-3">
            <textarea v-model="message" type="text" class="" id="MessageToHotel" @input="updateMessage" />   
        </div>
    </div>
</template>
<script>
export default {
    methods:{
        updateMessage(msg){
            this.$emit('message', this.message);
        }
    },
    data(){
        return{
            message: '',
        }
    },
    created(){
        this.message = this.$store.state.customerDetailsCheckout.Message;
    }
}
</script>
<style >
    #MessageToHotel{
        width: 75%;
        margin: 0 auto;
        margin-top: 30px;
    }

    .row{
        color:black;
    }
</style>