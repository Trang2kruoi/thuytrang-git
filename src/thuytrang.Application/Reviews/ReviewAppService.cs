using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.UI; // ✅ THÊM DÒNG NÀY (fix lỗi build)
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thuytrang.Reviews.Dto;

namespace thuytrang.Reviews
{
    [AbpAuthorize]
    public class ReviewAppService : thuytrangAppServiceBase, IReviewAppService
    {
        private readonly IRepository<Review, Guid> _reviewRepository;

        public ReviewAppService(IRepository<Review, Guid> reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        // GET DETAIL
        public async Task<ReviewDto> GetAsync(EntityDto<Guid> input)
        {
            var review = await _reviewRepository.GetAsync(input.Id);
            return ObjectMapper.Map<ReviewDto>(review);
        }

        // CREATE OR EDIT
        public async Task CreateOrEdit(CreateReviewDto input)
        {
            if (input.Id.HasValue)
            {
                var review = await _reviewRepository.GetAsync(input.Id.Value);
                ObjectMapper.Map(input, review);
                await _reviewRepository.UpdateAsync(review);
            }
            else
            {
                var review = ObjectMapper.Map<Review>(input);
                await _reviewRepository.InsertAsync(review);
            }
        }

        // DELETE
        public async Task Delete(EntityDto<Guid> input)
        {
            await _reviewRepository.DeleteAsync(input.Id);
        }

        // GET ALL (đã chống lỗi)
        public async Task<PagedResultDto<ReviewDto>> GetAll(PagedReviewResultRequestDto input)
        {
            try
            {
                var query = _reviewRepository.GetAll();

                var totalCount = await query.CountAsync();

                var list = await query
                    .OrderByDescending(x => x.Id) // dùng Id cho chắc
                    .PageBy(input)
                    .ToListAsync();

                return new PagedResultDto<ReviewDto>(
                    totalCount,
                    ObjectMapper.Map<List<ReviewDto>>(list)
                );
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException("Lỗi khi lấy danh sách review: " + ex.Message);
            }
        }
    }
}