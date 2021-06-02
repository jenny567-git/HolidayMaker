<template>
    <div>
        <h3>Saved hotel #</h3>
        <strong>{{hotel.hotelName}}</strong>
        <small>{{hotel.hotelDescription}}</small>
    </div>
</template>

<script>

export default {
    props:{
        hotel: {}
    }
}
</script>

<style >
    
</style>