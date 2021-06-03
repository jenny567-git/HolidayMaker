<template >
    <div>
        <div class="row g-3">
            <textarea type="text" class="" id="MessageToHotel" @input="updateMessage" />   
        </div>
    </div>
</template>
<script>
export default {
    methods:{
        updateMessage(msg){
            this.$emit('message', msg);
        }
    }
}
</script>
<style >
    #MessageToHotel{
        width: 75%;
        margin: 0 auto;
        margin-top: 30px;
    }
</style>