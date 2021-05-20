<template>
  <div>
    <input
      class="form-control"
      list="datalistOptions"
      id="searchInput"
      placeholder="Type to search..."
      @change="searchFieldChange"
      v-model="searchString"
    />
    <datalist id="datalistOptions">
      <option :value="hotel.name" v-for="hotel in hotels" :key="hotel.id" />
    </datalist>
  </div>
</template>

<script>
export default {
  data(){
    return{
      searchString: ''
    }
  },
  computed: {
    hotels() {
      return this.$store.state.hotels;
    },
  },
  methods:{
    searchFieldChange(){
      this.$emit('input-changed', this.searchString)
    }
  }
};
</script>

<style>
</style>