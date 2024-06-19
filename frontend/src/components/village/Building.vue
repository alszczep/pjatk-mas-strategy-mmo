<script setup lang="ts">
  import { routes } from "../../routes"

  const { imageUrl, level, villageId, placeInVillage } = defineProps<{
    imageUrl?: string
    level?: number
    villageId: string
    placeInVillage: number
  }>()
</script>

<template>
  <router-link
    :to="routes.game.village.building.withParam(villageId, placeInVillage)"
    class="wrapper"
  >
    <img :src="imageUrl" class="image" />
    <div v-if="level !== undefined" class="level">{{ level }}</div>
    <div class="background" />
  </router-link>
</template>

<style scoped>
  .wrapper {
    display: flex;
    justify-content: space-between;
    width: 100%;
    height: 100%;
    position: relative;
  }

  .image {
    width: 100%;
    object-fit: contain;
    object-position: center bottom;
    z-index: 5;
  }
  .background {
    background: #a6edaa;
    width: 100%;
    height: 20px;

    position: absolute;
    bottom: 0;
    right: 0;
    left: 0;
    z-index: 4;

    clip-path: ellipse(closest-side farthest-side);
  }

  .level {
    display: flex;
    align-items: center;
    justify-content: center;

    width: 28px;
    height: 28px;

    background: #333333af;
    color: white;

    border: 2px solid #000000;
    border-radius: 50%;

    position: absolute;
    bottom: -6px;
    right: -8px;
    z-index: 6;
  }
</style>
