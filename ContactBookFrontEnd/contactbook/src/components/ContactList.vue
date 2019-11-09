<template>
  <div>
      <ul>
          <li v-for="(cat, index) in cats" :key="index">{{ cat.name }}</li>
      </ul>
      <br>
      <input v-model="newCat">
      <button v-on:click="addCat">
          Add
      </button>
  </div>
</template>

<script lang="ts">
import { ContactRequest } from "../models/contactRequest";
export default {
  name: 'ContactNameList',
  data() {
      return {
        cats: [
            { name: 'one'},
            { name: 'two'},
            { name: 'three'},
            { name: 'four'}
        ],
        newCat: ''
      }
  },
  methods: {
      addCat: function() {         
          return this.cats.push({name: this.newCat})
      }
  }
}
</script>

<style scoped lang="scss">
.red {
    background-color: red;
}
.green {
    background-color:green;
}
</style>