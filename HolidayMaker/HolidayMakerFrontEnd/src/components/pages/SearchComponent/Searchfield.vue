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
      <option :value="item.name" v-for="item in autoComplete" :key="item.id" />
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
    autoComplete() {
      return this.$store.state.searchAutoComplete;
    },
  },
  created(){
      console.log('created');
      this.GetAutoComplete();
      //this.emitToParent('getAutoComplete');
    },
  methods:{
    GetAutoComplete(){
      this.$store.dispatch('getAutoComplete')
    },
    // emitToParent(){
    //         this.$emit('getAutoComplete')
    //     },
    searchFieldChange(){
      this.$emit('input-changed', this.searchString)
    }
  }
};
</script>

<style>
</style>