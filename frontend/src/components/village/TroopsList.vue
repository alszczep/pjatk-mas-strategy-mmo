<script setup lang="ts">
  const { troops } = defineProps<{
    troops: {
      name: string
      imageUrl: string
      count: number
    }[]
  }>()
</script>

<template>
  <v-card class="card">
    <v-card-title>Troops</v-card-title>
    <v-card-text class="text">
      <div v-for="troop in troops" :key="troop.name" class="troop">
        <img :src="troop.imageUrl" />
        <div>{{ troop.name }}</div>
        -
        <div>{{ troop.count }}</div>
      </div>
    </v-card-text>
  </v-card>
</template>

<style scoped>
  .card {
    width: 100%;
    height: 100%;
  }

  .text {
    display: flex;
    flex-direction: column;
    gap: 8px;
  }

  .troop {
    display: flex;
    gap: 12px;
    align-items: center;
  }

  .troop > img {
    width: 28px;
    height: 28px;
  }
</style>
