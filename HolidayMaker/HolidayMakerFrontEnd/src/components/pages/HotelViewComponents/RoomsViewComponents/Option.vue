<template>
  <div>
    <h3>Extra bed</h3>
    <div class="p-field-checkbox">
          <Checkbox id="option" v-model="extraBed" :binary="true" @change="emitToParent"/>
          <label for="option">{{ extraBed }}</label>
        </div>
  </div>
</template>

<script>
import Card from "primevue/card";
import Checkbox from "primevue/checkbox";

export default {
  components: {
    Checkbox,
    Card
  },
  computed:{
    extraBed:{
      get(){
        return this.$store.state.bookingDetails.extraBed;
      },
      set(){
        this.$store.dispatch('updateExtraBed');
      }
    }
  },
  methods:{
    emitToParent(e){
      this.$emit('checked');
    }
  }
};
</script>

<style scoped>
  h3{
    padding-top:30px;
  }

  .p-field-checkbox{
    padding-left:60mm;
  }

  label{
    display:none;
  }
</style>