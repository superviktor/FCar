<template>
  <div>
    <button @click="openDialog">Create Deck</button>

    <div v-if="showDialog" class="dialog-overlay">
      <div class="dialog">
        <h3>Create a new Deck</h3>

        <input v-model="deckName" placeholder="Enter deck name" />

        <div class="dialog-actions">
          <button @click="submitDeck">Submit</button>
          <button @click="closeDialog">Cancel</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      showDialog: false, 
      deckName: '',      
    };
  },
  methods: {
    openDialog() {
      this.showDialog = true;
    },
    closeDialog() {
      this.showDialog = false;
      this.deckName = ''; 
    },
    async submitDeck() {
      if (this.deckName.trim() === '') {
        alert('Deck name cannot be empty');
        return;
      }

      try {
        const response = await fetch('https://localhost:7287/deck', {
          method: 'POST',
          headers: { 'Content-Type': 'application/json' },
          body: JSON.stringify({ name: this.deckName }),
        });

        if (response.ok) {
          alert('Deck created successfully!');
          this.closeDialog();

          this.$emit('refreshDecks');
        } else {
          const errorData = await response.json();
          alert('Error creating deck: ' + errorData.message);
        }
      } catch (error) {
        console.error('Error creating deck:', error);
        alert('Error creating deck');
      }
    },
  },
};
</script>

<style scoped>
.dialog-overlay {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background-color: rgba(0, 0, 0, 0.5);
  display: flex;
  justify-content: center;
  align-items: center;
}

.dialog {
  background-color: white;
  padding: 20px;
  border-radius: 5px;
  width: 300px;
  text-align: center;
}

.dialog-actions {
  margin-top: 20px;
  display: flex;
  justify-content: space-between;
}

button {
  padding: 10px 15px;
  border: none;
  background-color: #007bff;
  color: white;
  cursor: pointer;
}

button:hover {
  background-color: #0056b3;
}
</style>