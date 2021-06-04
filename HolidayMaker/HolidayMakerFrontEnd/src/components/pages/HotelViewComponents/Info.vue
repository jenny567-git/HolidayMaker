<template>
  <div>
        <p>Rating: <span class="badge rounded-pill bg-secondary">{{hotel.averageRating}}</span></p>
        <p>{{hotel.description}}</p>
        <p>Amentities</p>
        <p v-if="hotel.pool"> <i class="fas fa-check"></i> Pool</p>
        <p v-if="hotel.nightEntertainment"> <i class="fas fa-check"></i> Night Entertainment</p>
        <p v-if="hotel.childClub"> <i class="fas fa-check"></i> Kids club</p>
        <p v-if="hotel.restaurant"> <i class="fas fa-check"></i> Restaurant</p>
  </div>
</template>

<script>
export default {
  
  computed: {
    hotel() {
      return this.$store.state.hotel;
    },
  },
};
</script>

<style scoped>

  

</style>