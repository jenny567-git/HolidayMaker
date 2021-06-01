<template>
  <div>
    <h3>Service type:</h3>
    <div
      class="btn-group"
      role="group"
      aria-label="Basic radio toggle button group"
    >
      <input
        type="radio"
        class="btn-check"
        name="btnradio"
        id="btnSelfService"
       
        autocomplete="off"
        
        @click="emitToParent('SelfService')"
      />
      <label class="btn btn-outline-primary" for="btnSelfService">
        Self service
      </label>

      <input
        type="radio"
        class="btn-check"
        name="btnradio"
        
        id="btnHalfBoard"
        autocomplete="off"
        @click="emitToParent('HalfBoard')"
      />
      <label class="btn btn-outline-primary" for="btnHalfBoard">
        Half board
      </label>

      <input
        type="radio"
        class="btn-check"
        name="btnradio"
        
        id="btnFullBoard"
        autocomplete="off"
        @click="emitToParent('FullBoard')"
      />

      <label class="btn btn-outline-primary" for="btnFullBoard">
        Full board
      </label>

      <input
        type="radio"
        class="btn-check"
        name="btnradio"
        
        id="btnAllInclusive"
        autocomplete="off"
        @click="emitToParent('AllInclusive')"
      />
      <label class="btn btn-outline-primary" for="btnAllInclusive">
        All inclusive
      </label>
    </div>
  </div>
</template>

<script>
export default {
  methods:{
    emitToParent(value){
      this.$emit('serviceType', value);
    }
  }
};
</script>

<style>
</style>