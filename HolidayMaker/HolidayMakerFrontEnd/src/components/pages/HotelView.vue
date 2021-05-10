<template>
    <div>
        <h1>This is a hotel name {{hotel.name}}</h1>
    </div>
</template>


<script>
export default ({
    computed:{
        hotel(){
            return this.$store.state.hotels[this.$route.params.id];
        }
    }
})
</script>
