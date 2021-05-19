<template>
  <div>
    <input
      class="form-control"
      list="datalistOptions"
      id="searchInput"
      placeholder="Type to search..."
    />
    <datalist id="datalistOptions">
      <option :value="hotel.name" v-for="hotel in hotels" :key="hotel.id" />
    </datalist>
  </div>
</template>

<script>
export default {
  computed: {
    hotels() {
      return this.$store.state.hotels;
    },
  },
};
</script>

<style>
</style>