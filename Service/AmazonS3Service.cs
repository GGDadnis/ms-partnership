using Amazon.S3.Model;
using Amazon.S3;

namespace ms_partnership.Service
{
    public class AmazonS3Service
    {
        private readonly IAmazonS3 S3;
        private readonly string Bucketname;
        private readonly string baseUrlS3;

        public AmazonS3Service(IAmazonS3 S3, string Bucketname){
            this.S3 = S3;
            this.Bucketname = Bucketname;
            this.baseUrlS3 = $"https://{this.Bucketname}.s3.amazonaws.com/";
        }

        public async Task<string> SendAsync(Stream filestream, string key){
            key = key.Replace(this.baseUrlS3, "");
            await this.S3.PutObjectAsync(new PutObjectRequest(){
                BucketName = this.Bucketname,
                InputStream = filestream,
                Key = key
            });
            return this.baseUrlS3 + key;
        }

        public async Task<DeleteObjectResponse> DeleteAsync(string key){
            key = key.Replace(this.baseUrlS3, "");
            DeleteObjectResponse deleteResponse = await this.S3.DeleteObjectAsync(new DeleteObjectRequest(){
                BucketName = this.Bucketname,
                Key = key
            });
            return deleteResponse;
        }

    }
}