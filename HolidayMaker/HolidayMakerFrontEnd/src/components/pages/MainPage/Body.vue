<template>
  <div
    style="
      background: url(https://i.postimg.cc/ZnHTP71s/aircraft-airplane-boat-1575833.jpg);
    "
    class="page-holder bg-cover"
  >
    <PopularDestinations />
    <SelectedHotels />
  </div>
</template>

<script>
import PopularDestinations from "./PopularDestinations.vue";
import SelectedHotels from "./SelectedHotels.vue";

export default {
  components: {
    PopularDestinations,
    SelectedHotels,
  },
};
</script>

<style>
.page-holder {
  min-height: 100vh;
}

.bg-cover {
  background-size: cover !important;
}
</style>
