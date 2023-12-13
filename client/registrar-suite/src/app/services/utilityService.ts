export class UtilityService {  
  
  formatDate(date: string): string {
      try {
          const d = new Date(date);
          let month = '' + (d.getMonth() + 1);
          let day = '' + d.getDate();
          const year = d.getFullYear();
          if (month.length < 2) month = '0' + month;
          if (day.length < 2) day = '0' + day;
          return [year, month, day].join('-');
      } catch (error) {
        console.error('Error:', error);
        throw error; // Rethrow the error or handle it appropriately
      }
    }
    convertToReadable (dateString: string) :string {
      if(dateString === undefined || dateString === null || dateString ==='') return ''
      const options = { year: 'numeric', month: 'long', day: 'numeric' } as const;
      return new Date(dateString).toLocaleDateString('en-US', options);
 };
  }
