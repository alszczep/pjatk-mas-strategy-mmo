<script setup lang="ts">
import { ref, onMounted } from 'vue';

const users = ref<any[]>();

const fetchData = async () => {
  const response = await fetch('http://localhost:5152/users');
  const data = await response.json();
  users.value = data;
};

onMounted(() => {
  fetchData();
});
</script>

<template>
  <v-data-table :items="users"> </v-data-table>
</template>
