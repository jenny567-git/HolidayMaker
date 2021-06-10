<template>
  <div>
    <input
      class="form-control"
      id="searchInput"
      placeholder="Type to search..."
      @input="searchFieldChange"
      v-model="searchString"
      minlength="2"
    />
    <datalist id="datalistOptions">
      <option :value="item" v-for="item in autoComplete" :key="item.id" />
    </datalist>
  </div>
</template>

<script>

export default {
  data() {
    return {
      searchString: "",
    };
  },
  computed: {
    autoComplete() {
      return this.$store.state.searchAutoComplete;
    },
  },
  mounted() {
    this.GetAutoComplete();
    
  },
  methods: {
    GetAutoComplete() {
      this.$store.dispatch("getAutoComplete");
    },
    searchFieldChange() {
      this.$emit("input-changed", this.searchString);
      if(this.searchString.length >= 2){
        var input = document.querySelector("#searchInput")
        input.setAttribute("list", "datalistOptions")
      } else{
        var input = document.querySelector("#searchInput")
        input.setAttribute("list", "")
      }
    }
  },
};
</script>

<style scoped>

</style>