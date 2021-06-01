<template>
  <div>
    <h3>Extra bed</h3>
    <div class="p-field-checkbox">
          <Checkbox id="option" v-model="extraBed" :binary="true" @change="emitToParent"/>
          <label for="option">{{ extraBed }}</label>
        </div>



    <!-- with card -->

    <!-- <Card>
      <template #title>
        <h3>Extra bed</h3>
      </template>
      <template #content>
        <div class="p-field-checkbox">
          <Checkbox id="option" v-model="checked" :binary="true" />
          <label for="option">{{ checked }}</label>
        </div>
      </template>
    </Card> -->

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

<style>
</style>