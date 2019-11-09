<template>
 <div class="cbArea">
     <table class="cbook">
         <tr class="title">
             <td>Kontaktu grāmata</td>
         </tr>
         <tr>
             <td><ContactList></ContactList></td>
             <td>Dati</td>
         </tr>
     </table>
 </div>
</template>

<script lang="ts">
import ContactList from "../components/ContactList.vue";

export default {
    name: 'ContactBookMain',
    components: {
        ContactList
    }
}
</script>

<style scoped lang="scss">
.cbArea {
  margin: auto;
  width: 60%;
  border: 3px solid #73AD21;
}

</style>